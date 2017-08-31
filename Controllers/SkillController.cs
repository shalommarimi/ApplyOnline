using ApplyOnline.DataContext;
using ApplyOnline.Models;
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
        public ActionResult Skills(int id, Skill skill)
        {

            try
            {
                using (var dbContext = new DataDbContext())
                {

                    skill.FkApplicantId = id;
                    dbContext.Skills.Add(skill);
                    dbContext.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("References", "Reference", new { id = id });

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