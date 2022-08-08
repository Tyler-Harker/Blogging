using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Extensions;
using TylerHarker.Blogging.Repositories;

namespace TylerHarker.Blogging.BlobStorage
{
    public static class BlogServiceCollectionExtensions
    {
        public static BlogServiceCollection AddBlobStorageProvider(this BlogServiceCollection bloggingServices, BlobStorageProviderConfiguration config)
        {
            bloggingServices.RemoveDefaultBloggingRepository();
            bloggingServices.Services.AddSingleton<BlobStorageProviderConfiguration>(config);
            bloggingServices.Services.AddSingleton<IBlogRepository, BlogBlobStorageRepository>();
            return bloggingServices;
        }
    }
}
