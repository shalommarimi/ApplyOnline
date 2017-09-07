using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Services;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant

        [Authorize]
        public ActionResult Dashboard(int? id)
        {

            using (var dbContext = new DataDbContext())
            {
                var getPopulationList = dbContext.Populations.ToList();
                var getGenderList = dbContext.Gender.ToList();
                var getNationalityList = dbContext.Nationalities.ToList();
                var getMaritalList = dbContext.MaritalStatus.ToList();
                var getAppFieldList = dbContext.ApplicationField.ToList();
                var getAppTypeList = dbContext.ApplicationType.ToList();


                SelectList PopulationList = new SelectList(getPopulationList, "PkPopulationId", "PopulationValue");
                SelectList GenderList = new SelectList(getGenderList, "PkGenderId", "GenderValue");
                SelectList NationalityList = new SelectList(getNationalityList, "PkNationalityId", "NationalityValue");
                SelectList MaritalList = new SelectList(getMaritalList, "PkMaritalStatusId", "MaritalStatusValue");
                SelectList AppFieldList = new SelectList(getAppFieldList, "PkApplicationFieldId", "FieldName");
                SelectList AppTypeList = new SelectList(getAppTypeList, "PkApplicationTypeId", "ApplicationTypeName");


                ViewData["Population"] = PopulationList;
                ViewData["Gender"] = GenderList;
                ViewData["Nationality"] = NationalityList;
                ViewData["Marital"] = MaritalList;
                ViewData["AppType"] = AppTypeList;
                ViewData["AppField"] = AppFieldList;

            }



            if (id == null)
            {

                return RedirectToAction("Login", "Authenticate");
            }
            using (var db = new DataDbContext())
            {

                PersonalInformation user = db.PersonalInformations.Find(id);
                if (user == null && Session["FirstName"] == null && Session["LastName"] == null && Session["PkApplicantId"] != null)
                {
                    return RedirectToAction("Login", "Authenticate");
                }
                else
                {
                    user.New_Password = Session["Password"].ToString();
                    user.ConfirmPassword = Session["Password"].ToString();
                    return View(user);
                }

            }


        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dashboard(PersonalInformation user)
        {


            using (var dbContext = new DataDbContext())
            {
                var getPopulationList = dbContext.Populations.ToList();
                var getGenderList = dbContext.Gender.ToList();
                var getNationalityList = dbContext.Nationalities.ToList();
                var getMaritalList = dbContext.MaritalStatus.ToList();
                var getAppFieldList = dbContext.ApplicationField.ToList();
                var getAppTypeList = dbContext.ApplicationType.ToList();


                SelectList PopulationList = new SelectList(getPopulationList, "PkPopulationId", "PopulationValue");
                SelectList GenderList = new SelectList(getGenderList, "PkGenderId", "GenderValue");
                SelectList NationalityList = new SelectList(getNationalityList, "PkNationalityId", "NationalityValue");
                SelectList MaritalList = new SelectList(getMaritalList, "PkMaritalStatusId", "MaritalStatusValue");
                SelectList AppFieldList = new SelectList(getAppFieldList, "PkApplicationFieldId", "FieldName");
                SelectList AppTypeList = new SelectList(getAppTypeList, "PkApplicationTypeId", "ApplicationTypeName");


                ViewData["Population"] = PopulationList;
                ViewData["Gender"] = GenderList;
                ViewData["Nationality"] = NationalityList;
                ViewData["Marital"] = MaritalList;
                ViewData["AppType"] = AppTypeList;
                ViewData["AppField"] = AppFieldList;



                if (ModelState.IsValid)
                {

                    // Hashing Password before it is saved
                    var HashPassword = new Hashing();
                    user.New_Password = HashPassword.HashPassword(user.New_Password);
                    user.ConfirmPassword = HashPassword.HashPassword(user.ConfirmPassword);

                    dbContext.Entry(user).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    ViewBag.Updated = "Successfully Updated User";
                    return View("Dashboard");
                }
                else
                {
                    return View(user);
                }


            }

        }
    }
}