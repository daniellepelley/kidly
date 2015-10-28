namespace Kidly.CanonicalUrls.Converters
{
    public class NoTrailingSlashUrlConverter : IUrlConverter
    {
        public string Convert(string url)
        {
            return url.EndsWith("/") ? url.Substring(0, url.Length - 1) : url;
        }
    }
}