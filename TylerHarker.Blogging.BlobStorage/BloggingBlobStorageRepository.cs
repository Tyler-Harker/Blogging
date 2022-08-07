using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Models;
using TylerHarker.Blogging.Repositories;

namespace TylerHarker.Blogging.BlobStorage
{
    public class BloggingBlobStorageRepository : IBloggingRepository
    {
        private readonly BlobStorageProviderConfiguration _config;
        public BloggingBlobStorageRepository(BlobStorageProviderConfiguration config)
        {
            _config = config;
        }

        public Task<Blog> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Blog> ListBlogs()
        {
            throw new NotImplementedException();
        }

        public Task<Blog> Save(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
