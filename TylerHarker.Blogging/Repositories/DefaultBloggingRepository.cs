using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Models;

namespace TylerHarker.Blogging.Repositories
{
    public class DefaultBloggingRepository : IBloggingRepository
    {
        public Task<Blog> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Blob>> ListBlogs()
        {
            throw new NotImplementedException();
        }

        public Task<Blog> Save(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
