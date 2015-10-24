using System.Web.Mvc;

namespace RollYourOwnAuth.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string productName)
        {
            var model = new Product {Name = productName};
            return View(model);
        }
    }
}