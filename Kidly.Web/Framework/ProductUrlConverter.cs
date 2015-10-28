using Kidly.CanonicalUrls.Converters;
using Kidly.Web.Data;

namespace Kidly.Web.Framework
{
    public class ProductUrlConverter : IUrlConverter
    {
        private readonly IProductProvider _productProvider;
        private readonly IProductUrlBuilder _productUrlBuilder;
        private readonly IProductUrlIdExtractor _productUrlIdExtractor;

        public ProductUrlConverter(IProductProvider productProvider, IProductUrlIdExtractor productUrlIdExtractor, IProductUrlBuilder productUrlBuilder)
        {
            _productUrlIdExtractor = productUrlIdExtractor;
            _productUrlBuilder = productUrlBuilder;
            _productProvider = productProvider;
        }

        public string Convert(string url)
        {
            if (!url.StartsWith("/p/"))
            {
                return url;
            }

            var id = _productUrlIdExtractor.Extract(url);

            if (!id.HasValue)
            {
                return url;
            }

            var product = _productProvider.Get(id.Value);

            var correctUrl = _productUrlBuilder.Build(product);

            return correctUrl;
        }
    }
}