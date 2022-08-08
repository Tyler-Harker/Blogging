using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Repositories;
using TylerHarker.Blogging.Services;

namespace TylerHarker.Blogging.Extensions
{
    public static class IServicesCollectionExtensions
    {
        public static IBloggingServiceCollection AddBlogging(this IServiceCollection services)
        {
            services.AddTransient<IBloggingService, BloggingService>();
            services.AddTransient<IBloggingRepository, InMemoryBlogRepository>();
            return new IBloggingServiceCollection { Services = services };
        }
        public static IBloggingServiceCollection RemoveDefaultBloggingRepository(this IBloggingServiceCollection bloggingServices)
        {
            ServiceDescriptor serviceToRemove = null;
            foreach(var service in bloggingServices.Services)
            {
                if(service.ImplementationType == typeof(InMemoryBlogRepository))
                {
                    serviceToRemove = service;
                }
            }
            if(serviceToRemove != null)
            {
                bloggingServices.Services.Remove(serviceToRemove);
            }
            return bloggingServices;
        }
    }
}
