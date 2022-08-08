using Microsoft.Extensions.DependencyInjection;
using TylerHarker.Blogging.BlobStorage;
using TylerHarker.Blogging.Extensions;
using TylerHarker.Blogging.Repositories;
using TylerHarker.Blogging.Services;

namespace TylerHarker.Blogging.NUnit
{
    public class ServiceInjectionTests
    {
        private IServiceCollection _services;
        private IServiceProvider _serviceProvider;

        private BlobStorageProviderConfiguration _blobStorageConfig;
        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection();
            _blobStorageConfig = new BlobStorageProviderConfiguration();
        }

        [Test]
        public void AddBloggingAddsBloggingService()
        {
            _services.AddBlogging();
            _serviceProvider = _services.BuildServiceProvider();
            IBloggingService bloggingService = _serviceProvider.GetService<IBloggingService>();

            Assert.NotNull(bloggingService);
        }

        [Test]
        public void AddBloggingAddsDefaultBloggingRepository()
        {
            _services.AddBlogging();
            _serviceProvider = _services.BuildServiceProvider();
            IBloggingRepository bloggingRepository = _serviceProvider.GetService<IBloggingRepository>();

            Assert.NotNull(bloggingRepository);
        }

        [Test]
        public void AddBloggingBlobStorageProviderRemovesDefaultBloggingRepository()
        {
            _services.AddBlogging()
                .AddBlobStorageProvider(_blobStorageConfig);
            _serviceProvider = _services.BuildServiceProvider();

            IBloggingRepository bloggingRepository = _serviceProvider.GetService<IBloggingRepository>();
            Assert.That(typeof(InMemoryBlogRepository), Is.Not.EqualTo(bloggingRepository?.GetType()));
        }

        [Test]
        public void AddBloggingBlobStorageProviderAddsBlobStorageRepository()
        {
            _services.AddBlogging()
                .AddBlobStorageProvider(_blobStorageConfig);
            _serviceProvider = _services.BuildServiceProvider();

            IBloggingRepository bloggingRepository = _serviceProvider.GetService<IBloggingRepository>();
            Assert.That(typeof(BloggingBlobStorageRepository), Is.EqualTo(bloggingRepository?.GetType()));
        }
    }
}