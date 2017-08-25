using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplyController : Controller
    {
        DataDbContext dbContext = new DataDbContext();
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
