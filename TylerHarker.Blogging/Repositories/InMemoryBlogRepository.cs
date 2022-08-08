using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Models;

namespace TylerHarker.Blogging.Repositories
{
    public class InMemoryBlogRepository : IBlogRepository, IInMemoryBlogRepository
    {
        private Dictionary<Guid, Blog> _blogs = new Dictionary<Guid, Blog>();

        public async Task<Blog> GetById(Guid id)
        {
            await Task.CompletedTask;
            return _blogs.GetValueOrDefault(id);
        }

        public IQueryable<Blog> ListBlogs()
        {
            return _blogs.Values.AsQueryable();
        }

        public async Task<Blog> Save(Blog blog)
        {
            await Task.CompletedTask;
            if(blog.Id == Guid.Empty)
            {
                blog.SetCreatedTrue();
            }
            _blogs[blog.Id] = blog;
            return blog;
        }
    }
}
