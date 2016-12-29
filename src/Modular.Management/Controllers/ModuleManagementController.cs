using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modular.Core;

namespace Modular.Management
{
    public class ModuleManagementController : Controller
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleManagementController(IModuleRepository moduleRepository)
        {
            if (moduleRepository == null) throw new ArgumentNullException(nameof(moduleRepository));

            _moduleRepository = moduleRepository;
        }

        [Route("Management")]
        public async Task<IActionResult> Index()
        {
            var modules = await _moduleRepository.GetModulesAsync();

            var viewModel = new ModuleManagementViewModel();

            foreach (var module in modules)
            {
                var moduleViewModel = new ModuleManagementViewModel.ModuleManagementModuleViewModel 
                {
                    Name = module.Name
                };

                viewModel.Modules.Add(moduleViewModel);
            }

            return View(viewModel);
        } 
    }
}