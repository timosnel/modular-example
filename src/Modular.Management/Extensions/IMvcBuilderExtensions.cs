using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Modular.Management
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder UseManagement(this IMvcBuilder mvcBuilder)
        {
            var managementAssembly = typeof(ModuleManagementController).GetTypeInfo().Assembly;
            var fileProvider = new EmbeddedFileProvider(managementAssembly);
            
            mvcBuilder.AddApplicationPart(managementAssembly);
            mvcBuilder.AddRazorOptions(options =>
			{
                options.FileProviders.Add(fileProvider);
			});

            return mvcBuilder;
        }
    }
}