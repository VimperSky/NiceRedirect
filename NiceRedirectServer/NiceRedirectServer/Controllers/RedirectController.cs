using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NiceRedirectServer.Models;
using NiceRedirectServer.Storage;

namespace NiceRedirectServer.Controllers
{
    public class RedirectController : ControllerBase
    {
        private readonly ILogger<RedirectManagerController> _logger;
        private readonly IStorage _storage;
        private readonly IOptions<EndPointOptions> _endPointOptions;

        public RedirectController(ILogger<RedirectManagerController> logger, IStorage storage, IOptions<EndPointOptions> endPointOptions)
        {
            _logger = logger;
            _storage = storage;
            _endPointOptions = endPointOptions;
        }

        private RedirectResult NotFoundRedirect() =>
            Redirect(Path.Combine(_endPointOptions.Value.FrontEndAddress,_endPointOptions.Value.NotFoundAddress));

        [HttpGet]
        public ActionResult<Redirect> DoRedirect(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return NotFoundRedirect();
            
            var redirect = _storage.GetRedirect(key);
            if (redirect == null) // Redirect to Angular NotFound page
                return NotFoundRedirect();

            return Redirect(new UriBuilder(redirect.Target).Uri.ToString());
        }
    }
}