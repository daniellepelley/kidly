namespace Kidly.Web.Framework
{
    public interface IProductUrlIdExtractor
    {
        int? Extract(string url);
    }
}