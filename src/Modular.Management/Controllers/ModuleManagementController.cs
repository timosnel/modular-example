using Microsoft.AspNetCore.Mvc;

namespace Modular.Management
{
    public class ModuleManagementController : Controller
    {
        [Route("Management")]
        public IActionResult Index()
        {
            return View();
        } 
    }
}