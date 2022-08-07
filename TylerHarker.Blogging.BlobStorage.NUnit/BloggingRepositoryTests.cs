using TylerHarker.Blogging.Repositories;
using TylerHarker.Blogging.BlobStorage.NUnit;

namespace TylerHarker.Blogging.BlobStorage.NUnit
{
    public class BloggingRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            IBloggingRepository repository = new BloggingBlobStorageRepository();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}