using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Services;

namespace TylerHarker.Blogging.Extensions
{
    public static class IServicesCollectionExtensions
    {
        public static IBloggingServiceCollection AddBlogging(this IServiceCollection services)
        {
            services.AddTransient<IBloggingService, BloggingService>();
            return (IBloggingServiceCollection)services;
        }
    }
}
