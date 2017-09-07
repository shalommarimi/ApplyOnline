using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        [Authorize]
        public ActionResult Dashboard()
        {
            if (Session["FirstName"] != null && Session["LastName"] != null && Session["PkApplicantId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Authenticate");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new DataDbContext();
            PersonalInformation user = db.PersonalInformations.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalInformation user)
        {
            var db = new DataDbContext();
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(user);
        }
    }
}