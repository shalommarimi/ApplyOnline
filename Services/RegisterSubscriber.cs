using ApplyOnline.DataContext;
using ApplyOnline.Models;

namespace ApplyOnline.Services
{
    public class RegisterSubscriber
    {
        public void Register(Subscribe sub)
        {

            using (var context = new DataDbContext())
            {

                try
                {
                    var subscribe = new Subscribe
                    {
                        FirstName = sub.FirstName,
                        LastName = sub.LastName,
                        EmailAddress = sub.EmailAddress,
                        FkGenderId = sub.FkGenderId

                    };
                    context.Subscribers.Add(subscribe);
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