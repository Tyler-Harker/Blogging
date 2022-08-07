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
    public class BloggingBlobStorageRepositoryTests
    {
        private IServiceCollection _services;
        private IServiceProvider _serviceProvider;
        private IBloggingRepository _bloggingRepository;


        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection();
            _services.AddBlogging()
                .AddBlobStorageProvider(new BlobStorageProviderConfiguration
                {
                    AccountName = "devstoreaccount1",
                    AccountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw=="
                });
            _serviceProvider = _services.BuildServiceProvider();
            _bloggingRepository = _serviceProvider.GetRequiredService<IBloggingRepository>();

        }

        [Test]
        public void BlobStorageRepositoryStartsEmpty()
        {
            var blogsCount = _bloggingRepository.ListBlogs().Count();
            Assert.That(0, Is.EqualTo(blogsCount));
        }

        [Test]
        public void BlobStorageRepositoryCreateBlob()
        {
            var blog = new Blog("test blog", "this is a test", new List<string> { });
        }
    }
}
