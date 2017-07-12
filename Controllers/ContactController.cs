using System.Web.Mvc;

namespace ApplyOnline.Content
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult EmailUs()
        {
            return View();
        }
    }
}