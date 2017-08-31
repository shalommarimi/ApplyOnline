using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Completed()
        {
            return View();
        }
    }
}