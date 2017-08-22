using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Services;
using System.Linq;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult Login()
        {

            if (Session["FirstName"] != null && Session["LastName"] != null)
            {
                return RedirectToAction("Dashboard", "Applicant");
            }
            else
            {
                return View();
            }

        }



        [HttpPost]
        public ActionResult Login(PersonalInformation userInput)
        {

            using (var context = new DataDbContext())
            {
                try
                {
                    var hashInputPassword = new Hashing();
                    string inPuttedPassword = hashInputPassword.HashInput(userInput.New_Password);


                    var user = context.PersonalInformations.Single(u => u.New_Password == inPuttedPassword && u.Username == userInput.Username);
                    if (user != null)
                    {
                        Session["FirstName"] = user.FirstName.ToString();
                        Session["LastName"] = user.FirstName.ToString();
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