using ApplyOnline.DataContext;
using System;
using System.Linq;

namespace ApplyOnline.Services
{
    public class GetUsertId
    {

        public int GetApplicantId(string IdentityNumber)
        {
            using (var dbContext = new DataDbContext())
            {
                var ApplicantId = from personalInfo in dbContext.PersonalInformations
                                  where personalInfo.IdNumber == IdentityNumber
                                  select personalInfo.PkApplicantId;

                return Convert.ToInt32(ApplicantId);

            }

        }
    }
}