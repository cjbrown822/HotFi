using System.Threading.Tasks;
using HotFi.Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotFi.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropletController : AbstractController<DropletViewModel>
    {
        protected override async Task<DropletViewModel> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Create(DropletViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Update(string id, DropletViewModel vm)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IActionResult> Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}