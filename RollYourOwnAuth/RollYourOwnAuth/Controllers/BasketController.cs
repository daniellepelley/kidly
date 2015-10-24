using System.Web.Mvc;

namespace RollYourOwnAuth.Controllers
{
    public class BasketController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}