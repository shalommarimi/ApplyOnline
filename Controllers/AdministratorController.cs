using ApplyOnline.DataContext;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplyOnline.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        [Authorize]
        public ActionResult Dashboard()
        {
            if (Session["FirstName"] != null && Session["LastName"] != null)
            {
                return View();
            }
            else
            {
                return View();
            }

        }



        [HttpPost]
        public ActionResult Login(FormCollection admin)
        {

            using (var context = new DataDbContext())
            {
                try
                {
                    //var hashInputPassword = new Hashing();
                    //string inPuttedPassword = hashInputPassword.HashPassword(userInput.New_Password);
                    string Username = admin["txtUsername"];
                    string Password = admin["txtPassword"];

                    var user = context.Admin.Single(u => u.Password == Password && u.Username == Username);

                    if (user != null)
                    {
                        Session["FirstName"] = user.FirstName.ToString();
                        Session["LastName"] = user.LastName.ToString();
                        FormsAuthentication.SetAuthCookie(user.Username, false);
                        return RedirectToAction("Dashboard", "Administrator");

                    }

                }
                catch (System.Exception)
                {
                    ViewBag.ErrorAdmin = "Username or Password is incorrect";
                    return RedirectToAction("Index", "Home");

                }
            }
            ViewBag.ErrorAdmin = "Username or Password is incorrect";
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home"); ;
        }
    }
}