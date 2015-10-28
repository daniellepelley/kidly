using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kidly.CanonicalUrls.Converters;
using NUnit.Framework;

namespace Kidly.CanonicalUrls.Test
{
    public class CompositeUrlConverterTest
    {
        [TestCase("/P/BrandName", "/p/brandname/")]
        [TestCase("/P/BrandName/22", "/p/brandname/22/")]
        [TestCase("/p/britax/britax-b-agile-3-WHEEL-pushchair/2", "/p/britax/britax-b-agile-3-wheel-pushchair/2/")]
        [TestCase("/", "/")]
        [TestCase("", "/")]
        public void CompositeUrlConverter(string url, string expected)
        { 
            var sut = new CompositeUrlConverter(new LowerCaseUrlConverter(), new TrailingSlashUrlConverter());
            var actual = sut.Convert(url);
            Assert.AreEqual(expected, actual);
        }
    }
}
