using ApplyOnline.Models;
using ApplyOnline.Services;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class PostContentController : Controller
    {
        // GET: PostContent
        public ActionResult News()
        {
            return View();
        }



        [HttpPost]
        public ViewResult PostNews(NewContent content)
        {

            if (ModelState.IsValid == true)
            {
                var postNews = new PostLatest();

                content.PostEntryDate = System.DateTime.Now;

                postNews.NewsPost(content);

                //Send Notifications
                var notify = new Notifications();
                notify.SendNewContent(content);


                return View("News");

            }
            else
            {
                return View("News");
            }



        }
    }
}