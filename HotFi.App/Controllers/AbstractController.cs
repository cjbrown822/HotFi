using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotFi.App.Controllers
{
    public abstract class AbstractController<T> : ControllerBase where T : class
    {
        public virtual async Task<T> Get(string id)
        {
            return null;
        }

        public virtual async Task<IActionResult> Create(T vm)
        {
            return new CreatedResult("", vm);
        }

        public virtual async Task<IActionResult> Update(string id, T vm)
        {
            return Ok();
        }

        public virtual async Task<IActionResult> Delete(string id)
        {
            return Ok();
        }
    }
}