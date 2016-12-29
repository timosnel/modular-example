using System.Collections.Generic;

namespace Modular.Management
{
    public class ModuleManagementViewModel
    {
        public ModuleManagementViewModel()
        {
            Modules = new List<ModuleManagementModuleViewModel>();
        }

        public List<ModuleManagementModuleViewModel> Modules { get; }

        public class ModuleManagementModuleViewModel
        {
            public string Name { get; set; }
        }
    }
}