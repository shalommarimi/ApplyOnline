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

                    context.Subscribers.Add(sub);
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