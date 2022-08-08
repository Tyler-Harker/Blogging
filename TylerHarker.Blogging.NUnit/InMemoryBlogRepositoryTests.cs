using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Extensions;

namespace TylerHarker.Blogging.NUnit
{
    public class InMemoryBlogRepositoryTests : BaseRepositoryTests
    {
        public InMemoryBlogRepositoryTests() : base(services => services)
        {
        }
    }
}
