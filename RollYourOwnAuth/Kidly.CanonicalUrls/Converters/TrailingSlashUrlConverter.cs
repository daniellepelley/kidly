namespace Kidly.CanonicalUrls.Converters
{
    public class TrailingSlashUrlConverter : IUrlConverter
    {
        public string Convert(string url)
        {
            return !url.EndsWith("/") ? string.Format("{0}/", url) : url;
        }
    }
}