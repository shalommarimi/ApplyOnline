using Newtonsoft.Json.Linq;
using System.Net;
using System.Web;

namespace ApplyOnline.Services
{
    public class ValidateReCAPTCHA
    {
        public bool IsReCAPTCHAvalid()
        {
            var request = HttpContext.Current.Request;
            var response = request["g-recaptcha-response"];
            string secretKey = System.Configuration.ConfigurationManager.AppSettings["ReCaptcha.PrivateKey"];

            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));

            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            return status;
        }

    }
}