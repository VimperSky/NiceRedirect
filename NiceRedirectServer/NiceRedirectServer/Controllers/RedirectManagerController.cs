using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<Redirect> Post([FromBody]string target)
        {
            return await _redirectCreator.Create(target);
        }
        
        [HttpGet("List")]
        public async Task<ActionResult<Redirect>> Get()
        {
            return Ok(await _storage.GetRedirects());
        }
        
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromQuery]string key)
        {
            var deleted = await _storage.DeleteRedirect(key);
            return deleted ? Ok() : NotFound();
        }
    }
}