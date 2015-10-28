using Kidly.Web.Models;

namespace Kidly.Web.Framework
{
    public interface IProductUrlBuilder
    {
        string Build(Product product);
    }
}