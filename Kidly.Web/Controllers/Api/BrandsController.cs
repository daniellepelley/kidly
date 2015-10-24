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
            return StaticData.Brands.FirstOrDefault(x => x.Name.ToLowerInvariant() == id.ToLowerInvariant());
        }
    }
}