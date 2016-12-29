using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modular.Core
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetModulesAsync();
        void AddModule(Module module);
    }
}