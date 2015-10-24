using System.Web.Mvc;
using Kidly.Web.Models;

namespace Kidly.Web.Controllers
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