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

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<ApplicationType> ApplicationType { get; set; }
        public virtual DbSet<ApplicationField> ApplicationField { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Subscribe> Subscribers { get; set; }
        public virtual DbSet<NewContent> NewsContent { get; set; }


    }
}