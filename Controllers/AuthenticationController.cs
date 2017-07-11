using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Authenticate()
        {
            return View();
        }
    }
}