using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplyController : Controller
    {
        DataDbContext dbContext = new DataDbContext();
        // GET: Authentication
        public ActionResult PersonalInformation()
        {

            return View();
        }


        public ActionResult Qualifications()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Qualifications(int ApplicantId, Qualification qualification)
        {



            return View();
        }

        [HttpPost]

        public ActionResult PersonalInformation(PersonalInformation personal)
        {

            if (ModelState.IsValid)
            {

                using (var context = new DataDbContext())
                {
                    try
                    {

                        context.PersonalInformations.Add(personal);
                        context.SaveChanges();

                        ModelState.Clear();
                        ViewBag.MessageApplied = " Thank you for Applying " + personal.FirstName + " " + personal.LastName;
                        return View();

                    }
                    catch (System.Exception)
                    {

                        ViewBag.MessageErrorValidation = " Validation error occured!";
                        return View();
                    }


                }



            }
            else
            {
                ViewBag.MessageDidNotApply = " It seems like we could not send your Application";
                return View("ApplicationProcess");
            }

        }
    }
}
