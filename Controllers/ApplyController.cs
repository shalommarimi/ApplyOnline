using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using System.Linq;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplyController : Controller
    {

        // GET: Authentication
        public ActionResult PersonalInformation()
        {

            return View();
        }




        [HttpPost]

        public ActionResult PersonalInformation(PersonalInformation personal)
        {

            if (ModelState.IsValid)
            {

                using (var dbContext = new DataDbContext())
                {
                    try
                    {
                        if (!dbContext.PersonalInformations.Any(t => t.IdNumber.Equals(personal.IdNumber)))
                        {
                            dbContext.PersonalInformations.Add(personal);
                            dbContext.SaveChanges();




                            ModelState.Clear();
                            int id = personal.PkApplicantId;
                            return RedirectToAction("Qualification", "Education", new { id = id });

                        }
                        else
                        {
                            ModelState.Clear();
                            ViewBag.Exist = " Applicant with Identity Number " + personal.IdNumber + " already exits. Please go to \"LOGIN\"";
                            return View();
                        }



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
                return View();
            }

        }
    }
}
