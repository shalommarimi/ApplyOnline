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
            return View();
        }



        [HttpPost]

        public ViewResult Register(Subscribe subscribe)
        {


            if (ModelState.IsValid)
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

                            var registerSubscriber = new RegisterSubscriber();
                            registerSubscriber.Register(subscribe);



                            ViewBag.Message = "Thank you for subscribing " + subscribe.FirstName + "!";
                            ModelState.Clear();
                            return View("Index");
                        }
                    }
                    catch (System.Exception)
                    {

                        ViewBag.Message = "Error!";
                        ModelState.Clear();
                        return View("Index");
                    }

                }


            }
            else
            {
                ViewBag.Error = "Sorry! Could not subscribe User ";
                return View("Index");

            }

        }
    }
}