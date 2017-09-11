using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using ApplyOnline.Services;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplyOnline.Controllers
{
    public class ApplyController : Controller
    {


        public ActionResult PersonalInformation()
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
                return View();
            }


        }

        [HttpPost]

        public ActionResult PersonalInformation(PersonalInformation personal)
        {
            //Validate reCAPTCHA
            var captcha = new ValidateReCAPTCHA();
            bool result = captcha.IsReCAPTCHAvalid();


            //Populate Lists
            var dbContex = new DataDbContext();
            var getPopulationList = dbContex.Populations.ToList();
            var getGenderList = dbContex.Gender.ToList();
            var getNationalityList = dbContex.Nationalities.ToList();
            var getMaritalList = dbContex.MaritalStatus.ToList();
            var getAppFieldList = dbContex.ApplicationField.ToList();
            var getAppTypeList = dbContex.ApplicationType.ToList();






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

            if (ModelState.IsValid && result)
            {

                using (var dbContext = new DataDbContext())
                {
                    try
                    {
                        if (!dbContext.PersonalInformations.Any(t => t.IdNumber.Equals(personal.IdNumber)) || !dbContext.PersonalInformations.Any(t => t.EmailAddress.Equals(personal.EmailAddress)))
                        {


                            var HashPassword = new Hashing();

                            //Hashing Password before it is saved
                            personal.New_Password = HashPassword.HashPassword(personal.New_Password);
                            personal.ConfirmPassword = HashPassword.HashPassword(personal.ConfirmPassword);

                            //Default Image
                            personal.ImagePath = "~/ApplicantsImages/default.jpg";

                            dbContext.PersonalInformations.Add(personal);
                            dbContext.SaveChanges();
                            ModelState.Clear();

                            //Store UserId or ApplicantId on a Session, Pass it using session instead of appending on Url
                            Session["ApplicantID"] = personal.PkApplicantId;
                            return RedirectToAction("Qualification", "Education");

                        }
                        else
                        {
                            ViewBag.Exist = " Applicant with Identity Number " + personal.IdNumber + "or Email Address " + personal.EmailAddress + " already exits. Please go to \"LOGIN\"";
                            return View();
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
                ViewBag.DidNotApply = " Applicant Information or reCAPTCHA validation failed";
                return View();
            }



        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home"); ;
        }
    }
}
