using System.Threading.Tasks;
using HotFi.Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HotFi.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : AbstractController<ApplicationViewModel>
    {
        public ApplicationController(IConfiguration config) : base(config)
        {
        }

        public IActionResult Login()
        {
            var applicationLoginUrl = $"http://localhost:{_authPort}/oauth2/authorize?client_id={_clientId}&redirect_uri={Request.Scheme}://{Request.Host + _redirectUri}&response_type=code&code_challenge={_codeChallenge}&code_challenge_method=S256";
            return Redirect(applicationLoginUrl);
        }
        protected override async Task<ApplicationViewModel> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Create(ApplicationViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Update(string id, ApplicationViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}