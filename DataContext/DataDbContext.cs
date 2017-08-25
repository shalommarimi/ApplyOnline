using ApplyOnline.DataAccessLayer;
using ApplyOnline.Models;
using System.Data.Entity;

namespace ApplyOnline.DataContext
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base("DataDbContext")
        {
            Database.SetInitializer(new SeedDataContext());

        }

        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }
        public virtual DbSet<ApplicationType> ApplicationType { get; set; }
        public virtual DbSet<ApplicationField> ApplicationField { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Subscribe> Subscribers { get; set; }
        public virtual DbSet<NewContent> NewContent { get; set; }
        public DbSet<PasswordCredential> PasswordCredentials { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Population> Populations { get; set; }
    }
}