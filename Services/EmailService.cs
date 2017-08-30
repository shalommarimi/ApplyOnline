using System.Net.Mail;

namespace ApplyOnline.Services
{
    public class EmailService
    {
        public void SendEmail(string emailTo, string subject, string messagebody)
        {

            using (var mail = new MailMessage())
            {

                mail.To.Add(emailTo);
                mail.From = new MailAddress("donotreplyapplyonline@gmail.com");
                mail.Body = messagebody;
                // mail.Attachments(attachment);
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("donotreplyapplyonline@gmail.com", "Jedia.01");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }




        }
    }
}