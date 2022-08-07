using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylerHarker.Blogging.Models;

namespace TylerHarker.Blogging.NUnit
{
    public class BlobModelTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorSetsTitleAsExpected()
        {
            var blog = new Blog("test title", "test html", new List<string> { });
            Assert.That(blog.Title, Is.EqualTo("test title"));
        }

        [Test]
        public void ConstructorSetsHtmlAsExpected()
        {
            var blog = new Blog("test title", "test html", new List<string> { });
            Assert.That(blog.HtmlText, Is.EqualTo("test html"));
        }

        [Test]
        public void ConstructorSetsCorrectNumberOfTagsAsExpected1()
        {
            var blog = new Blog("test title", "test html", new List<string> { });
            Assert.That(blog.Tags.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorSetsCorrectNumberOfTagsAsExpected2()
        {
            var blog = new Blog("test title", "test html", new List<string> { "test tag" });
            Assert.That(blog.Tags.Count,Is.EqualTo(1));
        }

        [Test]
        public void ConstructorSetsTagsAsExpectedIfNullProvided()
        {
            var blog = new Blog("test title", "test html");
            Assert.That(blog.Tags, Is.Not.Null);
        }

    }
}
