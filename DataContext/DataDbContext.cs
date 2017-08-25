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
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<QualLevel> QualLevels { get; set; }
        public virtual DbSet<Population> Populations { get; set; }
        public virtual DbSet<MediaFiles> MediaFyles { get; set; }

    }
}