using System.Linq;

namespace Kidly.CanonicalUrls.Converters
{
    public class CompositeUrlConverter : IUrlConverter
    {
        private readonly IUrlConverter[] _converters;

        public CompositeUrlConverter(params IUrlConverter[] converters)
        {
            _converters = converters;
        }

        public string Convert(string url)
        {
            return _converters
                .Aggregate(url, (current, converter) =>
                    converter.Convert(current));
        }
    }
}