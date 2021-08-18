using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.IAppService.Auth;
using TaskManager.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection service)
        {
            var impls = typeof(ApplicationService).Assembly
                .GetTypes().Where(p=>!p.IsAbstract && !p.IsInterface && p.IsPublic).ToList();
            typeof(IAuthenticationService).Assembly
                .GetTypes().Where(p => p.IsInterface)
                .ToList()
                .ForEach(p =>
                {
                    var impl = impls.FirstOrDefault(t => t.GetInterfaces().Any(o => o == p));
                    if (impl != null)
                    {
                        service.AddScoped(p, impl);
                    }
                });
            return service;
        }
    }
}
