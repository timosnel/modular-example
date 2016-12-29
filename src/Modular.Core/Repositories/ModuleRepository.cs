using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modular.Core
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly List<Module> _modules;

        public ModuleRepository()
        {
            _modules = new List<Module>();
        }

        public async Task<List<Module>> GetModulesAsync()
        {
            return await Task.FromResult(_modules);
        }

        public void AddModule(Module module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            
            _modules.Add(module);
        }
    }
}