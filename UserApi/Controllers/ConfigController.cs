using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Configurations;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly Appinfo _appInfo;

        public ConfigController(Appinfo appinfo)
        {
            _appInfo = appinfo;
        }

        [HttpGet]
        public IActionResult GetConfigValue()
        {
            return Ok(_appInfo);
        }

    }
}
