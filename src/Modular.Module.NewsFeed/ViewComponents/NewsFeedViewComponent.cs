using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Modular.Module.NewsFeed
{
    public class NewsFeedViewComponent : ViewComponent 
    {
        public NewsFeedViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var model = await Task.FromResult(new NewsFeedViewModel 
            {
                Title = "News feed"
            });

            return View(model);
        } 
        
    }
}