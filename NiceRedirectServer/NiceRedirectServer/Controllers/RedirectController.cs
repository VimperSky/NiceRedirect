using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NiceRedirectServer.Logic;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class RedirectController : ControllerBase
    {
        private readonly RedirectCreator _redirectCreator;
        private readonly ILogger<RedirectController> _logger;

        public RedirectController(ILogger<RedirectController> logger)
        {
            _logger = logger;
            _redirectCreator = new RedirectCreator();
        }
        
        [HttpPost]
        public Redirect Post([FromBody]string target)
        {
            return _redirectCreator.Create(target);
        }
    }
}