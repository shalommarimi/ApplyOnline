using ApplyOnline.DataContext;
using ApplyOnline.Models;
using System.Linq;
using System.Net.Mail;

namespace ApplyOnline.Services
{
    public class Notifications
    {


        public void SendNewContent(string subject, string body)
        {
            using (var context = new DataDbContext())
            {

                IQueryable<Subscribe> query = from sub in context.Subscribers
                                              select sub;

                foreach (var s in query)
                {
                    try
                    {
                        using (var mail = new MailMessage())
                        {

                            mail.To.Add(s.EmailAddress);
                            mail.From = new MailAddress("learnerslogsystem@gmail.com");
                            mail.Subject = subject;
                            mail.Body = body;
                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential
                            ("learnerslogsystem@gmail.com", "Jedia.01");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }

            }
        }








    }

}


