using System.ComponentModel.DataAnnotations;

namespace ApplyOnline.Models
{
    public class AdministrationCredentials
    {
        [Key]
        public int PkAdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}