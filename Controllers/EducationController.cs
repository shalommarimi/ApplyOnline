using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        public ActionResult Qualification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Qualification(Qualification qualification)
        {

            if (ModelState.IsValid)
            {

                using (var context = new DataDbContext())
                {
                    try
                    {
                        if (Session["ApplicantID"] != null)
                        {
                            qualification.FkApplicantId = Convert.ToInt32(Session["ApplicantId"]);
                            context.Qualifications.Add(qualification);
                            context.SaveChanges();
                            ModelState.Clear();
                            return RedirectToAction("WorkExperience", "Work");
                        }
                        else
                        {
                            return RedirectToAction("Expired", "Session");
                        }



                    }
                    catch (System.Exception)
                    {

                        ViewBag.MessageErrorValidation = " Validation error occured!";
                        return View();
                    }


                }


            }
            else
            {
                ViewBag.MessageDidNotApply = " It seems like we could not send your Application";
                return View();
            }
        }
    }
}