namespace Kidly.CanonicalUrls.Converters
{
    public class UpperCaseUrlConverter : IUrlConverter
    {
        public string Convert(string url)
        {
            return url.ToUpperInvariant();
        }
    }
}