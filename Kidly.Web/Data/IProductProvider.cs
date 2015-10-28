using Kidly.Web.Models;

namespace Kidly.Web.Data
{
    public interface IProductProvider
    {
        Product Get(int id);
    }
}