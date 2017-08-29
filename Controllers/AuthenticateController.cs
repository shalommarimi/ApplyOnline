using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Services;
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
                    var hashInputPassword = new Hashing();
                    string inPuttedPassword = hashInputPassword.HashPassword(userInput.New_Password);


                    var user = context.PersonalInformations.Single(u => u.New_Password == inPuttedPassword && u.Username == userInput.Username);
                    if (user != null)
                    {
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