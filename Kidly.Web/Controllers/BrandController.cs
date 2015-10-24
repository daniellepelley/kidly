using System.Web.Mvc;
using Kidly.Web.Models;

namespace Kidly.Web.Controllers
{
    public class BrandController : Controller
    {
        public ActionResult Index(string brandName)
        {
            var model = new Brand {Name = brandName};
            return View(model);
        }
    }
}