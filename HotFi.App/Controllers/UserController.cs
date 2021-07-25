using System.Threading.Tasks;
using HotFi.App.Clients;
using HotFi.Library.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HotFi.App.Controllers
{
    public class UserController: AbstractController<UserViewModel>
    {

        public UserController(IConfiguration config) : base(config)
        {
        }

        protected override async Task<UserViewModel> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Create(UserViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Update(string id, UserViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}