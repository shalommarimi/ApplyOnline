using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Services;
using System.Linq;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplyController : Controller
    {


        public ActionResult PersonalInformation()
        {

            return View();
        }

        [HttpPost]

        public ActionResult PersonalInformation(PersonalInformation personal)
        {
            //Validate reCAPTCHA
            var captcha = new ValidateReCAPTCHA();
            bool result = captcha.IsReCAPTCHAvalid();


            if (ModelState.IsValid && result)
            {

                using (var dbContext = new DataDbContext())
                {
                    try
                    {
                        if (!dbContext.PersonalInformations.Any(t => t.IdNumber.Equals(personal.IdNumber)) || !dbContext.PersonalInformations.Any(t => t.EmailAddress.Equals(personal.EmailAddress)))
                        {
                            var HashPassword = new Hashing();

                            //Hashing Password before it is saved
                            personal.New_Password = HashPassword.HashPassword(personal.New_Password);
                            personal.ConfirmPassword = HashPassword.HashPassword(personal.ConfirmPassword);

                            dbContext.PersonalInformations.Add(personal);
                            dbContext.SaveChanges();
                            ModelState.Clear();

                            //Store UserId or ApplicantId on a Session, Pass it using session instead of appending on Url
                            Session["ApplicantID"] = personal.PkApplicantId;
                            return RedirectToAction("Qualification", "Education");

                        }
                        else
                        {
                            ViewBag.Exist = " Applicant with Identity Number " + personal.IdNumber + "or Email Address " + personal.EmailAddress + " already exits. Please go to \"LOGIN\"";
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
                ViewBag.DidNotApply = " Applicant Information or reCAPTCHA validation failed";
                return View();
            }

        }
    }
}
