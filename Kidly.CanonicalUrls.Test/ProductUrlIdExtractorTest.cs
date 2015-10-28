using Kidly.Web.Framework;
using NUnit.Framework;

namespace Kidly.CanonicalUrls.Test
{
    public class ProductUrlIdExtractorTest
    {
        [TestCase("/p/britax/britax-b-agile-3-wheel-pushchair/2/", 2)]
        [TestCase("/p/britax/teddybear/2", 2)]
        [TestCase("/p/somebrandname/someproductname/", null)]
        [TestCase("/p/somebrandname/someproductname/notanumber", null)]
        [TestCase("/p/somebrandname/someproductname/4/?colour=red", 4)]
        public void Test(string url, int? expected)
        {
            var sut = new ProductUrlIdExtractor();

            var actual = sut.Extract(url);
            Assert.AreEqual(expected, actual);
        }
    }
}