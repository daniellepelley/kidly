using Kidly.Web.Data;
using Kidly.Web.Framework;
using Kidly.Web.Models;
using Moq;
using NUnit.Framework;

namespace Kidly.CanonicalUrls.Test
{
    public class ProductUrlConverterTest
    {
        [TestCase("/p/britax/britax-b-agile-3-wheel-pushchair/2/", "/p/britax/britax-b-agile-3-wheel-pushchair/2/")]
        [TestCase("/p/britax/teddybear/2/", "/p/britax/britax-b-agile-3-wheel-pushchair/2/")]
        [TestCase("/p/somebrandname/someproductname/2/", "/p/britax/britax-b-agile-3-wheel-pushchair/2/")]
        public void Test(string url, string expected)
        {
            var mockProductProvider = new Mock<IProductProvider>();

            mockProductProvider.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new Product
                {
                    Id = 2,
                    Ref = "britax-b-agile-3-wheel-pushchair",
                    Brand = new Brand
                    {
                        Name = "Britax"
                    }
                });


            var mockProductUrlIdExtractor = new Mock<IProductUrlIdExtractor>();

            mockProductUrlIdExtractor.Setup(x => x.Extract(It.IsAny<string>()))
                .Returns(1);

            var sut = new ProductUrlConverter(mockProductProvider.Object, mockProductUrlIdExtractor.Object, new ProductUrlBuilder());

            var actual = sut.Convert(url);
            Assert.AreEqual(expected, actual);
        }
    }
}