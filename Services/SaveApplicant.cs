using ApplyOnline.DataAccessLayer;
using ApplyOnline.DataContext;
using System.Web.Mvc;

namespace ApplyOnline.Services
{
    public class SaveApplicant
    {

        [HttpPost]
        public void InsertApplicant(PersonalInformation personal)
        {
            using (var context = new DataDbContext())
            {
                try
                {

                    //  string salt = "Thisismydefaultsaltwithsomespicesandherbs";

                    var hashingObject = new Hashing();
                    string hashedPassword = hashingObject.HashInput(personal.New_Password);
                    string hashedIdentityNumber = hashingObject.HashInput(personal.IdNumber);

                    //var person = new PersonalInformation
                    //{


                    //    FirstName = personal.FirstName,
                    //    MiddleName = personal.MiddleName,
                    //    LastName = personal.LastName,
                    //    FkGenderId = personal.FkGenderId,
                    //    IdNumber = hashedIdentityNumber,
                    //    FkNationalityId = personal.FkNationalityId,
                    //    FkPopulationId = personal.FkPopulationId,
                    //    CellNumber = personal.CellNumber,
                    //    EmailAddress = personal.EmailAddress,
                    //    DriversLicence = personal.DriversLicence,
                    //    FkMaritalStatusId = personal.FkMaritalStatusId,
                    //    HomeLanguage = personal.HomeLanguage,
                    //    PreferedCL = personal.PreferedCL,
                    //    FisrtOtherLanguage = personal.FisrtOtherLanguage,
                    //    SecondOtherLanguage = personal.SecondOtherLanguage,
                    //    ThirdOtherLanguage = personal.ThirdOtherLanguage,
                    //    IsDeleted = false,
                    //    FkApplicationFieldId = personal.FkApplicationFieldId,
                    //    FkApplicationTypeId = personal.FkApplicationTypeId,
                    //    Username = personal.Username,
                    //    New_Password = hashedPassword,
                    //    ConfirmPassword = personal.ConfirmPassword

                    //};
                    context.PersonalInformations.Add(personal);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }

        }

    }
}