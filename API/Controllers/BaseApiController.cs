using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]

        public class BaseApiController : ControllerBase
        {

        }
    }

//* [ApiController] özniteliği, bu sınıfın bir Web API denetleyicisi olduğunu belirtir. Bu öznitelik, ASP.NET Core'un varsayılan davranışını ayarlar, örneğin, HTTP isteklerinden gelen parametreleri doğrudan sınıf özelliklerine bağlar, doğru yanıt kodlarını otomatik olarak ayarlar ve bazı hata durumlarında uygun yanıt kodlarını oluşturur.

//* [Route] özniteliği, bu denetleyicinin API rotasını belirler. [controller] özelliği, bu denetleyicinin adının sonundaki "Controller" kelimesini atlayarak, rotanın temelini belirler. Örneğin, bu denetleyicinin adı "BaseApiController" ise, rotası "api/baseapi" olur.

//* BaseApiController sınıfı, ControllerBase sınıfından türetilir ve tüm API denetleyicileri için bir temel sınıf olarak kullanılabilir. Bu sınıf, tüm API denetleyicilerinin yararlanabileceği ortak işlevleri sağlamak için kullanılabilir