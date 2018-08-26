using System.Linq;
using CheckLinksConsole;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WithoutHttpAtStartOfLink_NoLinks()
        {
            var links = LinkChecker.GetLinks("", "<a href=\"google.com\">");
            Assert.AreEqual(links.Count(), 0);
        }

        [Test]
        public void WithHttpAtStartOfLink_LinkParses()
        {
            var links = LinkChecker.GetLinks("", "<a href=\"http://google.com\">");
            Assert.AreEqual(links.Count(), 1);
            Assert.AreEqual(links.First(), "http://google.com");
        }

    }
}