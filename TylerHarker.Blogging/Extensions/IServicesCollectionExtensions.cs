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
        public static BlogServiceCollection AddBlogging(this IServiceCollection services)
        {
            var inMemoryBlogRepository = new InMemoryBlogRepository();
            services.AddTransient<IBlogService, BlogService>();
            services.AddSingleton<IBlogRepository, InMemoryBlogRepository>(n => inMemoryBlogRepository);
            services.AddSingleton<IInMemoryBlogRepository, InMemoryBlogRepository>(n => inMemoryBlogRepository);
            return new BlogServiceCollection { Services = services };
        }
        public static BlogServiceCollection RemoveDefaultBloggingRepository(this BlogServiceCollection bloggingServices)
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
