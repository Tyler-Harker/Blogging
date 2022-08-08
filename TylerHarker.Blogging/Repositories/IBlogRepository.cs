using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Models;

namespace TylerHarker.Blogging.Repositories
{
    public interface IBlogRepository
    {
        Task<Blog> Save(Blog blog);
        Task<Blog> GetById(Guid id);
        IQueryable<Blog> ListBlogs();
    }
}
