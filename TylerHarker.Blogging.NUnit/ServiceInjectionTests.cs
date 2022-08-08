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
            _blobStorageConfig = new BlobStorageProviderConfiguration
            {
                ConnectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;"
            };
        }

        [Test]
        public void AddBloggingAddsBloggingService()
        {
            _services.AddBlogging();
            _serviceProvider = _services.BuildServiceProvider();
            IBlogService bloggingService = _serviceProvider.GetService<IBlogService>();

            Assert.NotNull(bloggingService);
        }

        [Test]
        public void AddBloggingAddsDefaultBloggingRepository()
        {
            _services.AddBlogging();
            _serviceProvider = _services.BuildServiceProvider();
            IBlogRepository bloggingRepository = _serviceProvider.GetService<IBlogRepository>();

            Assert.NotNull(bloggingRepository);
        }

        [Test]
        public void AddBloggingBlobStorageProviderRemovesDefaultBloggingRepository()
        {
            _services.AddBlogging()
                .AddBlobStorageProvider(_blobStorageConfig);
            _serviceProvider = _services.BuildServiceProvider();

            IBlogRepository bloggingRepository = _serviceProvider.GetService<IBlogRepository>();
            Assert.That(typeof(InMemoryBlogRepositoryTests), Is.Not.EqualTo(bloggingRepository?.GetType()));
        }

        [Test]
        public void AddBloggingBlobStorageProviderAddsBlobStorageRepository()
        {
            _services.AddBlogging()
                .AddBlobStorageProvider(_blobStorageConfig);
            _serviceProvider = _services.BuildServiceProvider();

            IBlogRepository bloggingRepository = _serviceProvider.GetService<IBlogRepository>();
            Assert.That(typeof(BlogBlobStorageRepository), Is.EqualTo(bloggingRepository?.GetType()));
        }
    }
}