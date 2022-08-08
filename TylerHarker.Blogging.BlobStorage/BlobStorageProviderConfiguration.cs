using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerHarker.Blogging.BlobStorage
{
    public class BlobStorageProviderConfiguration
    {
        public string ConnectionString { get; set; }
        public string Container { get; set; } = "Blogs";
    }
}
