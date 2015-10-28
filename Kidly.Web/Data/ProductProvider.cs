using System.Linq;
using Kidly.Web.Controllers.Api;
using Kidly.Web.Framework;
using Kidly.Web.Models;

namespace Kidly.Web.Data
{
    public class ProductProvider : IProductProvider
    {
        public Product Get(int id)
        {
            var product = StaticData
                .Products
                .FirstOrDefault(x => x.Id == id);

            product.Brand = StaticData
                .Brands
                .FirstOrDefault(x => x.Id == product.BrandId);

            return product;
        }
    }
}