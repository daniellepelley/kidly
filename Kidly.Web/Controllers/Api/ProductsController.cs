using System.Web.Http;
using Kidly.Web.Models;

namespace Kidly.Web.Controllers.Api
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public LineItem Get(int id)
        {
            return StaticData.GetLineItem(id) ?? StaticData.CreateLineItem(id);
        }
    }
}