using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password  { get; set; }

        //* Biz burada her ne kadar büyük harfle bir değişken oluştursakta, program JSON verilerinin küçük harfle saklandığını bilir ve o yüzden bu bir sıkıntı oluşturmaz.

        //?  DTO (Data Transfer Object) genellikle veri tabanı işlemlerinde ve HTTP istekleriyle ilgili verilerin aktarımında kullanılan bir terimdir. DTO'lar, belirli bir işlem için gereken verileri tutan ve bu verileri farklı sistemler arasında aktarmak için kullanılan bir nesne türüdür. Django'daki serializer'lara benziyorlar.
    }
}