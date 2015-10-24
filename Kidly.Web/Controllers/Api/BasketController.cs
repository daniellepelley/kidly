using System.Linq;
using System.Web.Http;
using Kidly.Web.Models;

namespace Kidly.Web.Controllers.Api
{
    
    public class BasketController : ApiController
    {
        [HttpGet]
        [Route("api/basket/add/{id}/{quantity}")]
        public bool Add(int id, int quantity)
        {
            var lineItem = StaticData.GetLineItem(id);

            if (lineItem == null)
            {
                lineItem = StaticData.CreateLineItem(id);
                StaticData.LineItems.Add(lineItem);
            }

            lineItem.Quantity += quantity;

            return true;
        }

        [HttpGet]
        [Route("api/basket/remove/{id}")]
        public bool Remove(int id)
        {
            StaticData.LineItems.Remove(
                StaticData.LineItems.FirstOrDefault(x => x.Product.Id == id));
            return true;
        }

        [HttpGet]
        [Route("api/basket/set/{id}/{quantity}")]
        public bool Set(int id, int quantity)
        {
            var lineItem = StaticData.GetLineItem(id);

            if (lineItem == null)
            {
                lineItem = StaticData.CreateLineItem(id);
                StaticData.LineItems.Add(lineItem);
            }

            lineItem.Quantity = quantity;

            return true;
        }

        [HttpGet]
        public LineItem[] Get()
        {
            return StaticData.LineItems.ToArray();
        }

        [HttpGet]
        [Route("api/basket/clear")]
        public bool Clear()
        {
            StaticData.LineItems.Clear();
            return true;
        }

        [HttpPost]
        [Route("api/basket/update/")]
        public void Update(LineItem[] lineItems)
        {

        }


    }

   

}