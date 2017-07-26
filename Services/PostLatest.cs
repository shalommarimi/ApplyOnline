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
                    var objNewsContent = new NewContent
                    {
                        PostSubject = content.PostSubject,
                        PostBody = content.PostBody,
                        PostType = content.PostType,
                        PostEntryDate = content.PostEntryDate


                    };
                    context.NewsContent.Add(objNewsContent);
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