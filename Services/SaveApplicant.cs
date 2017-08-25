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


                    var passwordHashing = new Hashing();

                    personal.IdNumber = passwordHashing.HashPassword(personal.IdNumber);
                    personal.New_Password = passwordHashing.HashPassword(personal.New_Password);

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