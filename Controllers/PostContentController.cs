using ApplyOnline.Models;
using ApplyOnline.Services;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class PostContentController : Controller
    {



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

                ViewBag.Success = "Your entry has been sucessfully posted";
                ModelState.Clear();
                return RedirectToAction("Dashboard", "Administrator");

            }
            else
            {
                ViewBag.Error = "Could not post entry";
                return RedirectToAction("Dashboard", "Administrator");
            }



        }
    }
}