using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotFi.App.Controllers
{
    public abstract class AbstractController<T> : ControllerBase where T : class
    {
        protected abstract Task<T> Get(string id);

        public abstract Task<IActionResult> Create(T vm);

        public abstract Task<IActionResult> Update(string id, T vm);

        public abstract Task<IActionResult> Delete(string id);
    }
}