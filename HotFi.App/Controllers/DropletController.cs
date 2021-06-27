using System.Threading.Tasks;
using HotFi.Library.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotFi.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropletController : AbstractController<DropletViewModel>
    {
        [HttpGet("{id}")]
        public override async Task<DropletViewModel> Get(string id)
        {
            return null;
        }

        [HttpPost("")]
        public override Task<IActionResult> Create(DropletViewModel vm)
        {
            return base.Create(vm);
        }

        [HttpPut("{id}")]
        public override Task<IActionResult> Update(string id, DropletViewModel vm)
        {
            return base.Update(id, vm);
        }

        [HttpDelete("{id}")]
        public override Task<IActionResult> Delete(string id)
        {
            return base.Delete(id);
        }
    }
}