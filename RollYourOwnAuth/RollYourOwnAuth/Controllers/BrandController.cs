using System.Web.Mvc;

namespace RollYourOwnAuth.Controllers
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