namespace Kidly.CanonicalUrls.Converters
{
    public class LowerCaseUrlConverter : IUrlConverter
    {
        public string Convert(string url)
        {
            return url.ToLowerInvariant();
        }
    }
}