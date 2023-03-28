using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//* Bu kod, ASP.NET Core web uygulamasında MVC (Model-View-Controller) mimarisini kullanarak, bir veya daha fazla denetleyicinin eklenmesini sağlar.
//* AddControllers() metodu, uygulamaya denetleyici eklemek için kullanılır. Bu metot, uygulamada kullanılacak olan denetleyicileri içeren bir ControllerBuilder nesnesi oluşturur.
//* Denetleyiciler, isteklere yanıt olarak belirli bir işlemi gerçekleştirmek için kullanılır. Bir denetleyici, ControllerBase sınıfından türetilir ve HTTP isteklerine yanıt veren bir dizi yöntem içerir.


builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//* Bu kod, ASP.NET Core web uygulamasında, bir Entity Framework Core veritabanı bağlamının oluşturulmasını sağlar.
//* AddDbContext<DataContext>() metodu, uygulamaya bir veritabanı bağlamı eklemek için kullanılır. Bu metot, bir DbContextOptions nesnesi oluşturur ve veritabanına bağlanmak için gereken ayarları yapılandırmak için kullanılabilir.
//* opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")) yöntemi, SQLite veritabanına bağlanmak için kullanılan bağlantı dizesini yapılandırır. Bu yöntem, "DefaultConnection" adlı bir bağlantı dizesi belirleyerek appsettings.json (burada appsettings.Development.json) dosyasından bu bağlantı dizesini alır.


builder.Services.AddCors();
//* Bu kod, ASP.NET Core web uygulamasında Cross-Origin Resource Sharing (CORS) özelliğini etkinleştirmek için kullanılır.
//* AddCors() metodu, uygulamaya CORS özelliğini eklemek için kullanılır. Bu metot, bir CorsServiceBuilder nesnesi oluşturur ve CORS politikalarını yapılandırmak için kullanılabilen bir dizi farklı yöntem sağlar.
//* CORS, web uygulamalarının farklı kaynaklardan gelen istekleri kabul etmesini sağlar. Bu özellik, güvenlik açısından önemlidir ve uygulamaların yalnızca güvenilir kaynaklardan gelen istekleri kabul etmesini sağlar.


var app = builder.Build();
//* Bu kod, ASP.NET Core web uygulamasının yapısını tamamlamak için kullanılır.
//* builder.Build() metodu, uygulamanın yapılandırılmasını tamamlar ve bir IApplicationBuilder nesnesi döndürür. Bu nesne, uygulama için bir HTTP isteği işleyicisi olarak kullanılabilir.


app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
//* Bu kod, ASP.NET Core web uygulamasında Cross-Origin Resource Sharing (CORS) özelliğini etkinleştirir ve belirli bir istemci kaynağına izin verir.
//* UseCors() metodu, CORS özelliğini uygulamaya eklemek için kullanılır. Bu metot, bir CorsPolicyBuilder nesnesi oluşturur ve CORS politikasını yapılandırmak için kullanılabilen bir dizi farklı yöntem sağlar.
//* AllowAnyHeader() ve AllowAnyMethod() yöntemleri, herhangi bir HTTP isteği başlığına ve HTTP yöntemine izin verir.
//* WithOrigins("http://localhost:4200") yöntemi, yalnızca "http://localhost:4200" kaynağından gelen isteklere izin verir. 

app.MapControllers();

app.Run();
