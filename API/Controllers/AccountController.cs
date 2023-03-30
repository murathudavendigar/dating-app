using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Controllers
{
    public class AccountController : BaseApiController  //* bu sınıf isminin ilk kısmını api/<ilk kısım>/<yazacığımız endpoint adı> şeklinde alıyor
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")] //? POST : api/account/register
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDto)
        {

            if(await UserExist(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512(); //* using keyword'ünü kullanarak bu sınıfla işimiz bittiğinde onu dispose ediyoruz. yani garbage collector aracılığıyla bellekten atabiliyoruz

            var user = new AppUser{
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user); //* burda entity framework'üne bir şey eklemek istediğimizi söylüyoruz
            await _context.SaveChangesAsync(); //* Burda da veritabanımızın böyle bir şey yapabilmesi için async bir şekilde bunu kaydetmesi gerekiyor

            return user;
        }

        [HttpPost("login")] //? POST : api/account/login
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if(user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return user;

        }

        private async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}