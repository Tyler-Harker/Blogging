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
            Assert.That(blogsCount, Is.EqualTo(0));
        }

        [Test]
        public async Task BlobStorageRepositoryCreateBlobIdIsSet()
        {
            var blog = new Blog("test blog", "this is a test");
            await _bloggingRepository.Save(blog);

            Assert.That(blog.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public async Task BlobStorageRepositoryCreatedBlobCanBeGottenById()
        {
            var blog = new Blog("test blob", "test");
            await _bloggingRepository.Save(blog);

            var blogById = await _bloggingRepository.GetById(blog.Id);
            Assert.That(blogById, Is.EqualTo(blog));
        }

        [Test]
        public async Task GetListReturnsSingleResult()
        {
            var blog = new Blog("test blog", "test");
            await _bloggingRepository.Save(blog);

            var blogs = _bloggingRepository.ListBlogs().ToList();
            Assert.That(blogs.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetListReturnsMultipleResults()
        {
            var blog1 = new Blog("test blog 1", "test");
            var blog2 = new Blog("test blog 2", "test");

            await _bloggingRepository.Save(blog1);
            await _bloggingRepository.Save(blog2);

            var blogs = _bloggingRepository.ListBlogs().ToList();
            Assert.That(blogs.Count, Is.EqualTo(2));
        }
    }
}
