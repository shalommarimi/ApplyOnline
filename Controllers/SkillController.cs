using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult Skills()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Skills(Skill skill)
        {

            try
            {
                using (var dbContext = new DataDbContext())
                {
                    if (Session["ApplicantID"] != null)
                    {
                        skill.FkApplicantId = Convert.ToInt32(Session["ApplicantID"]);
                        dbContext.Skills.Add(skill);
                        dbContext.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("References", "Reference");
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