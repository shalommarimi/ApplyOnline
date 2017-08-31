using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Expired()
        {
            return View();
        }
    }
}