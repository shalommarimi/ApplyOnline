using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System;

namespace ApplyOnline.Services
{
    public class PostLatest
    {
        public void NewsPost(NewContent content)
        {
            using (var context = new DataDbContext())
            {
                try
                {
                    context.NewContent.Add(content);
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}