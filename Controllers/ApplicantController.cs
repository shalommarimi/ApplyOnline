using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult Dashboard()
        {
            if (Session["FirstName"] != null && Session["LastName"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Authenticate");
        }
    }
}