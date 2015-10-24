using System.Collections.Generic;

namespace Kidly.CanonicalUrls.Converters
{
    public class MappedUrlConverter : IUrlConverter
    {
        private readonly IDictionary<string, string> _urlMapping;

        public MappedUrlConverter(IDictionary<string, string> urlMapping)
        {
            _urlMapping = urlMapping;
        }

        public string Convert(string url)
        {
            return _urlMapping.ContainsKey(url) ? _urlMapping[url] : url;
        }
    }
}