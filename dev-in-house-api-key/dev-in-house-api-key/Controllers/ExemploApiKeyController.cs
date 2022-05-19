using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dev_in_house_api_key.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemploApiKeyController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery(Name = "apikey")] string apiKey)
        {
            return Ok($"Conteudo recebido no meu Query String. API KEY VALUE {apiKey}");
        }

    }
}
