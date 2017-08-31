using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Reference
        public ActionResult References()
        {
            return View();
        }

        [HttpPost]
        public ActionResult References(int id, Reference reference)
        {
            try
            {
                using (var dbContext = new DataDbContext())
                {
                    reference.FkApplicantId = id;
                    dbContext.References.Add(reference);
                    dbContext.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Completed", "Application");
                }
            }
            catch (System.Exception)
            {
                ViewBag.MessageErrorValidation = " Validation error occured!";
                return View(); throw;
            }

        }
    }
}