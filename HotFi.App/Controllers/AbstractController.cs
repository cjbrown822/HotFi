using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HotFi.App.Controllers
{
    public abstract class AbstractController<T> : ControllerBase where T : class
    {
        private readonly IConfiguration _config;
        protected readonly int _authPort;
        protected readonly string _clientId;
        protected readonly string _redirectUri;
        protected readonly string _codeChallenge;
        public AbstractController(IConfiguration config)
        {
            _config = config;
            _authPort = int.Parse(GetConfigSection("Auth", "AuthPort"));
            _clientId = GetConfigSection("Auth", "ClientId");
            _redirectUri = GetConfigSection("Auth", "RedirectUrl");
            _codeChallenge = GetConfigSection("Auth", "CodeChallenge");
        }
        protected abstract Task<T> Get(string id);

        public abstract Task<IActionResult> Create(T vm);

        public abstract Task<IActionResult> Update(string id, T vm);

        public abstract Task<IActionResult> Delete(string id);

        protected string GetConfigSection(string section, string key) =>
            _config.GetSection(section)?.GetSection(key)?.Value;

        protected string GetConfigSection(string section) => _config.GetSection(section)?.Value;
    }
}