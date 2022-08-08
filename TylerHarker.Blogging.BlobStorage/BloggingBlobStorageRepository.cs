using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TylerHarker.Blogging.Models;
using TylerHarker.Blogging.Repositories;

namespace TylerHarker.Blogging.BlobStorage
{
    public class BloggingBlobStorageRepository : IBloggingRepository
    {
        private readonly BlobStorageProviderConfiguration _config;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _blobContainerClient;
        public BloggingBlobStorageRepository(BlobStorageProviderConfiguration config)
        {
            _config = config;
            _blobServiceClient = new BlobServiceClient(config.ConnectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(config.Container) ?? _blobServiceClient.CreateBlobContainer(config.Container);
        }

        public Task<Blog> GetById(Guid id)
        {

            throw new NotImplementedException();
        }

        public IQueryable<Blog> ListBlogs()
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> Save(Blog blog)
        {
            if(blog.Id == Guid.Empty)
            {
                blog.SetCreatedTrue();
                
            }
            var jsonBlog = JsonSerializer.Serialize(blog);
            var bytes = Convert.FromBase64String(jsonBlog);
            using (var stream = new MemoryStream(bytes))
            {
                await _blobContainerClient.UploadBlobAsync(blog.Id.ToString(), stream);
            }
            return blog;
        }
    }
}
