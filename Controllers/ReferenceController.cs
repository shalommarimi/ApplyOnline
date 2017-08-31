using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System;
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
        public ActionResult References(Reference reference)
        {
            try
            {
                using (var dbContext = new DataDbContext())
                {
                    if ((Session["ApplicantID"] != null))
                    {
                        reference.FkApplicantId = Convert.ToInt32(Session["ApplicantID"]);
                        dbContext.References.Add(reference);
                        dbContext.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Completed", "Application");
                    }
                    else
                    {
                        return RedirectToAction("Expired", "Session");
                    }

                }
            }
            catch (Exception)
            {
                ViewBag.MessageErrorValidation = " Validation error occured!";
                return View(); throw;
            }

        }
    }
}