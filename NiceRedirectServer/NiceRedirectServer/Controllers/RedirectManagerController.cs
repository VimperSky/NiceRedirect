using Microsoft.AspNetCore.Mvc;
using NiceRedirectServer.Logic;
using NiceRedirectServer.Models;
using NiceRedirectServer.Storage;

namespace NiceRedirectServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class RedirectManagerController : ControllerBase
    {
        private readonly RedirectCreator _redirectCreator;
        private readonly IStorage _storage;

        public RedirectManagerController(RedirectCreator redirectCreator, IStorage storage)
        {
            _redirectCreator = redirectCreator;
            _storage = storage;
        }
        
        [HttpPost("Create")]
        public Redirect Post([FromBody]string target)
        {
            return _redirectCreator.Create(target);
        }
        
        [HttpGet("List")]
        public ActionResult<Redirect> Get()
        {
            return Ok(_storage.GetRedirects());
        }
    }
}