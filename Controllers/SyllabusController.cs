using System.Net.Mail;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class SyllabusController : Controller
    {
        // GET: Syllabus
        public ActionResult Syllabus()
        {
            return View();
        }
        [HttpPost]

        public ViewResult Syllabus(Models.Email email)
        {


            if (ModelState.IsValid)
            {


                using (var mail = new MailMessage())
                {

                    mail.To.Add("shalommarimi@gmail.com");
                    mail.From = new MailAddress("learnerslogsystem@gmail.com");
                    mail.Subject = email.Subject + " Sender Email: " + email.SentFrom;
                    mail.Body = "Enquiry Content: " + email.Message;
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
                return View("Syllabus");
            }
            else
            {
                return View();
            }
        }
    }
}