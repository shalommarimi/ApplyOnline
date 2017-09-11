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
        public ActionResult Login(FormCollection login)
        {
            Session["Password"] = login["txtPassword"];

            using (var context = new DataDbContext())
            {
                try
                {
                    //Comparing entered Password before it is compared
                    var hash = new Hashing();
                    string Password = login["txtPassword"] = hash.HashPassword(login["txtPassword"]);
                    string Username = login["txtUsername"];


                    var user = context.PersonalInformations.Single(u => u.New_Password == Password && u.Username == Username);
                    if (user != null)
                    {
                        Session["PkApplicantId"] = Convert.ToInt32(user.PkApplicantId);
                        Session["FirstName"] = user.FirstName.ToString();
                        Session["LastName"] = user.LastName.ToString();
                        Session["Image"] = user.ImagePath.ToString();


                        FormsAuthentication.SetAuthCookie(user.Username, false);
                        return RedirectToAction("Dashboard", "Applicant", new { id = Session["PkApplicantId"] });

                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Username or Password is incorrect");

                }
            }
            return View();


        }
    }
}