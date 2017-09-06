using System.Net.Mail;
using System.Web.Mvc;

namespace ApplyOnline.Controllers
{
    public class ContactController : Controller
    {
        // GET: Syllabus
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]

        public ViewResult Send(FormCollection email)
        {


            if (ModelState.IsValid)
            {
                string emailFrom = email["txtEmail"];
                string subject = email["txtSubject"];
                string message = email["txtMessage"];

                using (var mail = new MailMessage())
                {

                    mail.To.Add("shalommarimi@gmail.com");
                    mail.From = new MailAddress("learnerslogsystem@gmail.com");
                    mail.Subject = "Sender: " + emailFrom;
                    mail.Body = "Enquiry Content: " + message;
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
                ViewBag.Sent = "Your enquiry has been sent. We will respond to you soon";
                return View("Contact");
            }
            else
            {
                return View();
            }
        }
    }
}