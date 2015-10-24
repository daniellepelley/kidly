using System.Web.Http;

namespace RollYourOwnAuth.Controllers.Api
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