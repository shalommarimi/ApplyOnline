using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult WorkExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WorkExperience(WorkExprience work)
        {
            try
            {
                using (var dbContext = new DataDbContext())
                {
                    if (Session["ApplicantID"] != null)
                    {
                        work.FkApplicantId = Convert.ToInt32(Session["ApplicantID"]);
                        dbContext.WorkExpriences.Add(work);
                        dbContext.SaveChanges();

                        ModelState.Clear();
                        return RedirectToAction("Skills", "Skill");
                    }
                    else
                    {
                        return RedirectToAction("Expired", "Session");
                    }

                }
            }
            catch (System.Exception)
            {

                ViewBag.MessageErrorValidation = " Validation error occured!";
                return View();
            }

        }
    }
}