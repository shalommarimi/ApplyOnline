using ApplyOnline.DataContext;
using ApplyOnline.Models;
using ApplyOnline.Services;
using System.Linq;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home



        public ActionResult Index()
        {

            using (var dbContext = new DataDbContext())
            {
                var getGenderList = dbContext.Gender.ToList();
                SelectList GenderList = new SelectList(getGenderList, "PkGenderId", "GenderValue");
                ViewData["Sex"] = GenderList;
                return View();

            }

        }



        [HttpPost]
        public ViewResult Register(Subscribe subscribe)
        {

            var captcha = new ValidateReCAPTCHA();
            bool result = captcha.IsReCAPTCHAvalid();


            using (var dbContext = new DataDbContext())
            {
                var getGenderList = dbContext.Gender.ToList();
                SelectList GenderList = new SelectList(getGenderList, "PkGenderId", "GenderValue");
                ViewData["Sex"] = GenderList;

            }

            if (ModelState.IsValid && result)
            {
                using (var dbContext = new DataDbContext())
                {

                    try
                    {

                        if (dbContext.Subscribers.Any(t => t.EmailAddress.Equals(subscribe.EmailAddress)))
                        {

                            ViewBag.Error = "The email \"" + subscribe.EmailAddress + "\" already exists!";
                            ModelState.Clear();
                            return View("Index");

                        }
                        else
                        {


                            dbContext.Subscribers.Add(subscribe);
                            dbContext.SaveChanges();


                            ViewBag.Message = "Thank you for subscribing " + subscribe.FirstName + "!";
                            ModelState.Clear();
                            return View("Index");
                        }
                    }
                    catch (System.Exception)
                    {

                        ViewBag.MessageSub = "Internal Error! Sorry for the inconvenience";
                        ModelState.Clear();
                        return View("Index");
                    }

                }


            }
            else
            {
                ViewBag.Error = " Could not subscribe User, reCAPTCHA or User Information verification failed";
                return View("Index");

            }

        }
    }
}