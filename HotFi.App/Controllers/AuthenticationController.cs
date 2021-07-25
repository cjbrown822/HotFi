using System.Threading.Tasks;
using HotFi.App.Clients;
using HotFi.Library.ViewModel.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp.Extensions;

namespace HotFi.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly AuthenticationHttpClient _authenticationHttpClient;
        private readonly IConfiguration _configuration;

        public AuthenticationController(AuthenticationHttpClient authenticationHttpClient, IConfiguration configuration)
        {
            _authenticationHttpClient = authenticationHttpClient;
            _configuration = configuration;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var authUrl = _configuration.GetSection("Auth").GetSection("AuthAddress").Value;
            var clientId = _configuration.GetSection("Auth").GetSection("ClientId").Value;
            var redirectUri = _configuration.GetSection("Auth").GetSection("RedirectUrl").Value;
            var loginUrl = $"{authUrl}/oauth2/authorize?client_id={clientId}&redirect_uri={redirectUri}&response_type=code";
            return Redirect(loginUrl);
        }

        [HttpGet("oauth-callback")]
        public async Task<IActionResult> OauthCallback([FromQuery] string code,[FromQuery]  string locale,[FromQuery]  string state)
        {
            var token = await _authenticationHttpClient.GetTokenWithCode(code);
            HttpContext.Session.SetString("token", JsonConvert.SerializeObject(token));
            return Ok(token);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            var accessTokenString = HttpContext.Session.GetString("token");
            if (accessTokenString.HasValue())
            {
                var accessTokenWrapper = JsonConvert.DeserializeObject<AccessTokenDataModel>(accessTokenString!);
                var userInfo = await _authenticationHttpClient.UserInfo(accessTokenWrapper!.AccessToken);
            
                return Ok(userInfo);
            }
            return NotFound();
        }
    }
}