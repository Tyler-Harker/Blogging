using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.BlobStorage;
using TylerHarker.Blogging.Extensions;
using TylerHarker.Blogging.Models;
using TylerHarker.Blogging.Repositories;
using TylerHarker.Blogging.Services;

namespace TylerHarker.Blogging.NUnit
{
    public class BlogBlobStorageRepositoryTests : BaseRepositoryTests
    {
        public BlogBlobStorageRepositoryTests() : base((services) => services.AddBlobStorageProvider(new BlobStorageProviderConfiguration
        {
            ConnectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;"
        }))
        {
            
        }
    }
}
