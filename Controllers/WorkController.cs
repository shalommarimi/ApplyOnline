using ApplyOnline.DataContext;
using ApplyOnline.Models;
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
        public ActionResult WorkExperience(int id, WorkExprience work)
        {
            try
            {
                using (var dbContext = new DataDbContext())
                {
                    work.FkApplicantId = id;
                    dbContext.WorkExpriences.Add(work);
                    dbContext.SaveChanges();

                    ModelState.Clear();
                    return RedirectToAction("Skills", "Skill", new { id = id });
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