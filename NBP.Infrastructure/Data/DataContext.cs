using Microsoft.EntityFrameworkCore;
using NBP.Domain.Entities;
using NBP.Domain.Identity;

namespace NBP.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TrainerUser> Trainers { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<ManagerS> Managers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<TrainerSalary> TrainerSalaries { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainerUser>().ToTable("Trainers");
            modelBuilder.Entity<Receptionist>().ToTable("Receptionists");
            modelBuilder.Entity<Administrator>().ToTable("Administrators");
            modelBuilder.Entity<ManagerS>().ToTable("Managers");
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Sponsor>().ToTable("Sponsors");
            modelBuilder.Entity<Payment>().ToTable("Payments");
        }
        //public DbSet<User>
    }
}
