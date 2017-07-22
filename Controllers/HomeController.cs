using ApplyOnline.Models;
using ApplyOnline.Services;
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

                var registerSubscriber = new RegisterSubscriber();
                registerSubscriber.Register(subscribe);

                ViewBag.Success = "Successfully Subscribed, Thank You!";
                return View("Index");
            }
            else
            {
                return View(ViewBag.Error = "Could not Subscribe User");
            }

        }
    }
}