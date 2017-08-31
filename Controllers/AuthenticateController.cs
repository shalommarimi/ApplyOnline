using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Services;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplyOnline.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        //[Authorize]
        public ActionResult Login()
        {
            return View();

        }



        [HttpPost]
        public ActionResult Login(PersonalInformation userInput)
        {

            using (var context = new DataDbContext())
            {
                try
                {
                    //Comparing entered Password before it is compared
                    var HashPassword = new Hashing();
                    userInput.New_Password = HashPassword.HashPassword(userInput.New_Password);


                    var user = context.PersonalInformations.Single(u => u.New_Password == userInput.New_Password && u.Username == userInput.Username);
                    if (user != null)
                    {
                        Session["PkApplicantId"] = Convert.ToInt32(user.PkApplicantId);
                        Session["FirstName"] = user.FirstName.ToString();
                        Session["LastName"] = user.FirstName.ToString();

                        FormsAuthentication.SetAuthCookie(user.Username, false);
                        return RedirectToAction("Dashboard", "Applicant");


                    }

                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Username or Password is incorrect");

                }
            }
            return View();


        }
    }
}