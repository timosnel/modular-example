using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Modular.ModuleB
{
    public class ModuleBViewComponent : ViewComponent 
    {
        public ModuleBViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var model = new ModuleBViewModel 
            {
                Title = "Module B"
            };

            return View(model);
        } 
        
    }
}