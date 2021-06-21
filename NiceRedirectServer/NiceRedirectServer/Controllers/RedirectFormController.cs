using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceRedirectServer.Data;
using NiceRedirectServer.Models;

namespace NiceRedirectServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class RedirectFormController : ControllerBase
    {
        private readonly RedirectContext _redirectContext;

        public RedirectFormController(RedirectContext redirectContext)
        {
            _redirectContext = redirectContext;
        }
        
        [HttpPost("ProcessPasswordForm")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> ProcessPasswordForm([FromBody]RedirectWithPassword redirectWithPassword)
        {
            var item = await _redirectContext.Redirects.FirstOrDefaultAsync(x => x.Key == redirectWithPassword.Key);
            if (item is null)
            {
                return NotFound();
            }

            if (item.Data.Password == redirectWithPassword.Password)
            {
                return Ok(item.Data.Target);
            }

            return Unauthorized();
        }
    }
}