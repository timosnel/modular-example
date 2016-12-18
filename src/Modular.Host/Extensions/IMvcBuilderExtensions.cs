using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace Modular.Host 
{
    public static class IMvcBuilderExtensions 
    {
        public static IMvcBuilder LoadModules(this IMvcBuilder mvcBuilder)
        {
            foreach (var library in DependencyContext.Default.RuntimeLibraries)
			{
				if (library.Name.StartsWith("Modular."))
				{
					var moduleAssembly = Assembly.Load(new AssemblyName(library.Name));
					mvcBuilder.AddApplicationPart(moduleAssembly);
				}
			}

			return mvcBuilder;
        }
    }
}