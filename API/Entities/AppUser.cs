namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}

//! Biz isimlendirmeyi her ne kadar PascalCase yapsakta api'den dönen veriler CamelCase dönüyor.