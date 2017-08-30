using ApplyOnline.Models;
using ApplyOnline.Services;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class PostContentController : Controller
    {


        [HttpPost]
        public ActionResult Send(FormCollection email)
        {

            try
            {
                var emailService = new EmailService();
                emailService.SendEmail(email["txtEmail"], email["txtSubject"], email["txtMessage"]);
                return RedirectToAction("Dashboard", "Administrator");
            }
            catch (System.Exception)
            {

                return RedirectToAction("Dashboard", "Administrator");
            }


        }



        [HttpPost]
        public ActionResult PostNews(NewContent content)
        {

            if (ModelState.IsValid == true)
            {

                content.PostEntryDate = System.DateTime.Now;

                var postNews = new PostLatest();
                postNews.NewsPost(content);

                //Send Notifications
                var notify = new Notifications();
                notify.SendNewContent(content);

                ViewBag.SuccessPost = "Your entry has been sucessfully posted";
                ModelState.Clear();
                return RedirectToAction("Dashboard", "Administrator");

            }
            else
            {
                ViewBag.ErrorPost = "Could not post entry";
                return RedirectToAction("Dashboard", "Administrator");
            }



        }
    }
}