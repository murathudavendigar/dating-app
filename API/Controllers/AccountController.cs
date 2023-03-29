using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512(); //* using keyword'ünü kullanarak bu sınıfla işimiz bittiğinde onu dispose ediyoruz. yani garbage collector aracılığıyla bellekten atabiliyoruz

            var user = new AppUser{
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user); //* burda entity framework'üne bir şey eklemek istediğimizi söylüyoruz
            await _context.SaveChangesAsync(); //* Burda da veritabanımızın böyle bir şey yapabilmesi için async bir şekilde bunu kaydetmesi gerekiyor

            return user;
        }
    }
}