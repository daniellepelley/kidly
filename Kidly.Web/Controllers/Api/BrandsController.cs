using System.Linq;
using System.Web.Http;
using Kidly.Web.Models;

namespace Kidly.Web.Controllers.Api
{
    public class BrandsController : ApiController
    {
        [HttpGet]
        public Brand Get(string id)
        {
            var brand = StaticData.Brands.FirstOrDefault(x => x.Name.ToLowerInvariant() == id.ToLowerInvariant());
            brand.Products = StaticData.Products.Where(x => x.BrandId == brand.Id).ToList();
            return brand;
        }

        [HttpGet]
        public Brand[] Get()
        {
            return StaticData.Brands.Select(x =>
            {
                x.Products = StaticData.Products.Where(p => p.BrandId == x.Id).ToList();
                return x;
            }).ToArray();
        }

    }
}