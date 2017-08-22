using ApplyOnline.DataAccessLayer;
using ApplyOnline.Services;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplyController : Controller
    {
        // GET: Authentication
        public ActionResult ApplicationProcess()
        {

            return View();
        }

        [HttpPost]

        public ActionResult ApplicationProcess(PersonalInformation personal)
        {


            if (ModelState.IsValid)
            {

                var saveApplicant = new SaveApplicant();
                saveApplicant.InsertApplicant(personal);


                ModelState.Clear();
                ViewBag.Message = "Thank you! You have successfully Applied";

            }
            else
            {

            }
            return View("ApplicationProcess");
        }
    }
}
