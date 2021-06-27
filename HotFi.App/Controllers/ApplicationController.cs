using System.Threading.Tasks;
using HotFi.Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotFi.App.Controllers
{
    public class ApplicationController : AbstractController<ApplicationViewModel>
    {
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