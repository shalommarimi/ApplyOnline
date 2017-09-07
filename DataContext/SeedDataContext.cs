using ApplyOnline.DataAccessLayer;
using ApplyOnline.Models;
using ApplyOnline.Services;
using System.Collections.Generic;
using System.Data.Entity;

namespace ApplyOnline.DataContext
{
    public class SeedDataContext : DropCreateDatabaseIfModelChanges<DataDbContext>
    {
        protected override void Seed(DataDbContext context)
        {

            var hashingPassword = new Hashing();
            IList<AdministrationCredentials> admin = new List<AdministrationCredentials>();
            admin.Add(new AdministrationCredentials() { FirstName = "Shalom", LastName = "Marimi", Username = "shalommarimi@gmail.com", Password = hashingPassword.HashPassword("Lulama.01") });
            admin.Add(new AdministrationCredentials() { FirstName = "Lucky", LastName = "Mathebula", Username = "lucky@gmail.com", Password = hashingPassword.HashPassword("Lucky.01") });
            admin.Add(new AdministrationCredentials() { FirstName = "General", LastName = "System", Username = "general@gmail.com", Password = hashingPassword.HashPassword("General.01") });



            foreach (AdministrationCredentials adm in admin)
                context.Admin.Add(adm);


            IList<QualLevel> qualificationLevel = new List<QualLevel>();
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Certificate" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Higher Certificate" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Advanced Certificate" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "National Certificate" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Diploma" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "National Diploma" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Post Graduate Diploma" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Advanced Diploma" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Bachelor Degrees" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = " Baccalaureus Technologiae Degrees" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Honours Degrees" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "Masters" });
            qualificationLevel.Add(new QualLevel() { QualLevelValue = "PhD" });


            foreach (QualLevel qua in qualificationLevel)
                context.QualLevels.Add(qua);

            IList<Population> population = new List<Population>();
            population.Add(new Population() { PopulationValue = "African" });
            population.Add(new Population() { PopulationValue = "White" });
            population.Add(new Population() { PopulationValue = "Coloured" });
            population.Add(new Population() { PopulationValue = "Indian" });


            foreach (Population pop in population)
                context.Populations.Add(pop);



            IList<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { GenderValue = "Male" });
            genders.Add(new Gender() { GenderValue = "Female" });
            genders.Add(new Gender() { GenderValue = "Other" });


            foreach (Gender gen in genders)
                context.Gender.Add(gen);



            IList<Nationality> nationality = new List<Nationality>();
            nationality.Add(new Nationality() { NationalityValue = "South African" });
            nationality.Add(new Nationality() { NationalityValue = "Zimbabwen" });
            nationality.Add(new Nationality() { NationalityValue = "Angolian" });
            nationality.Add(new Nationality() { NationalityValue = "Limpopian" });



            foreach (Nationality nat in nationality)
                context.Nationalities.Add(nat);


            IList<MaritalStatus> maritalstatus = new List<MaritalStatus>();
            maritalstatus.Add(new MaritalStatus() { MaritalStatusValue = "Single" });
            maritalstatus.Add(new MaritalStatus() { MaritalStatusValue = "Married" });
            maritalstatus.Add(new MaritalStatus() { MaritalStatusValue = "Seperated" });
            maritalstatus.Add(new MaritalStatus() { MaritalStatusValue = "Complicated" });



            foreach (MaritalStatus marriage in maritalstatus)
                context.MaritalStatus.Add(marriage);



            IList<ApplicationType> applicationType = new List<ApplicationType>();
            applicationType.Add(new ApplicationType() { ApplicationTypeName = "Internship" });
            applicationType.Add(new ApplicationType() { ApplicationTypeName = "Learnership" });


            foreach (ApplicationType appTypeName in applicationType)
                context.ApplicationType.Add(appTypeName);



            IList<ApplicationField> applicationField = new List<ApplicationField>();
            applicationField.Add(new ApplicationField() { FieldName = "FET Systems Development", FieldCode = "48872" });
            applicationField.Add(new ApplicationField() { FieldName = "NC Systems Development", FieldCode = "98842" });
            applicationField.Add(new ApplicationField() { FieldName = "Business Analysis", FieldCode = "21548" });
            applicationField.Add(new ApplicationField() { FieldName = "Software Testing", FieldCode = "61545" });



            foreach (ApplicationField applicationFieldName in applicationField)
                context.ApplicationField.Add(applicationFieldName);



            base.Seed(context);
        }
    }
}