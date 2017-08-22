﻿using ApplyOnline.Models;
using ApplyOnline.Services;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class PostContentController : Controller
    {
        // GET: PostContent
        public ActionResult Content()
        {
            return View();
        }



        [HttpPost]
        public ViewResult PostNews(NewContent content)
        {

            if (ModelState.IsValid == true)
            {

                content.PostEntryDate = System.DateTime.Now;

                var postNews = new PostLatest();
                postNews.NewsPost(content);

                //Send Notifications
                var notify = new Notifications();
                notify.SendNewContent(content);


                return View("Content");

            }
            else
            {
                return View("Content");
            }



        }
    }
}