namespace ApplyOnline.Services
{
    public class EmailService
    {
        public void SendEmail(string emailTo, string User, string link)
        {

            //using (var mail = new MailMessage())
            //{
            //    var stringBuilder = new StringBuilder();
            //    mail.To.Add(s.EmailAddress);
            //    mail.From = new MailAddress("donotreplyapplyonline@gmail.com");
            //    mail.Subject = content.PostSubject;
            //    stringBuilder.Append("Hi " + s.FirstName + " " + s.LastName + "<br></br>");
            //    stringBuilder.Append("<br></br>" + content.PostBody + "<br></br>");
            //    stringBuilder.Append("<br></br>" + "Date Posted: " + content.PostEntryDate);
            //    mail.Body = stringBuilder.ToString();
            //    mail.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new System.Net.NetworkCredential
            //    ("donotreplyapplyonline@gmail.com", "Jedia.01");
            //    smtp.EnableSsl = true;
            //    smtp.Send(mail);
            //}




        }
    }
}