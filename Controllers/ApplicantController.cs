using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        [Authorize]
        public ActionResult Dashboard()
        {
            if (Session["FirstName"] != null && Session["LastName"] != null && Session["PkApplicantId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Authenticate");
        }
    }
}