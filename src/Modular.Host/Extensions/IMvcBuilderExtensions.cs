using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.FileProviders;
using Modular.Core;

namespace Modular.Host 
{
    public static class IMvcBuilderExtensions 
    {
		private const string modulePrefix = "Modular.Module.";

        public static IMvcBuilder LoadModules(this IMvcBuilder mvcBuilder, IModuleRepository moduleRepository)
        {
			var moduleAssemblies = new List<Assembly>();
			
            foreach (var library in DependencyContext.Default.RuntimeLibraries)
			{
				if (library.Name.StartsWith(modulePrefix))
				{
					var moduleAssembly = Assembly.Load(new AssemblyName(library.Name));
					moduleAssemblies.Add(moduleAssembly);

					// The prefix is 15 chars.
					var niceName = library.Name.Remove(0, 15); 
					
					// Insert the modules in the module repository.
					var module = new Modular.Core.Module(niceName);
					moduleRepository.AddModule(module);
				}
			}

			var fileProviders = new List<IFileProvider>();

			foreach (var moduleAssembly in moduleAssemblies)
			{
				// Add the module as an application part, so view components will be usable.
				mvcBuilder.AddApplicationPart(moduleAssembly);
				
				// Create an embedded file provider for static content like views.
				var fileProvider = new EmbeddedFileProvider(moduleAssembly);
				fileProviders.Add(fileProvider);
			}

			mvcBuilder.AddRazorOptions(options =>
			{
				// Add each file provider to the razor engine.
				foreach (var fileProvider in fileProviders)
				{
					options.FileProviders.Add(fileProvider);
				}
			});

			return mvcBuilder;
        }
    }
}