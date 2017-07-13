using System.Net.Mail;

namespace ApplyOnline.Services
{
    public class Notifications
    {

        public void SendEmail(string emailaddress, string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {

                    mail.To.Add("smarimi@jhb.dvt.co.za");
                    mail.From = new MailAddress("learnerslogsystem@gmail.com");
                    mail.Subject = (subject);
                    mail.Body = (message);
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


            }



        }
    }
}