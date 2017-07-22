using ApplyOnline.DataAccessLayer;
using ApplyOnline.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ApplyOnline.DataContext
{
    public class SeedDataContext : DropCreateDatabaseIfModelChanges<DataDbContext>
    {
        protected override void Seed(DataDbContext context)
        {

            IList<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { GenderValue = "Male" });
            genders.Add(new Gender() { GenderValue = "Female" });


            foreach (Gender gen in genders)
                context.Gender.Add(gen);
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