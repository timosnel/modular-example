using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Modular.ModuleA 
{
    public class ModuleAViewComponent : ViewComponent 
    {
        public ModuleAViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var model = new ModuleAViewModel 
            {
                Title = "Module A"
            };

            return View(model);
        } 
        
    }
}