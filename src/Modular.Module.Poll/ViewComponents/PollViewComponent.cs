using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Modular.Module.Poll
{
    public class PollViewComponent : ViewComponent 
    {
        public PollViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var model = await Task.FromResult(new PollViewModel 
            {
                Title = "Poll"
            });

            return View(model);
        } 
        
    }
}