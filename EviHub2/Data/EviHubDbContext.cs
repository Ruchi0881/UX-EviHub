using EviHub2.Data.Configurations;
using EviHub2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EviHub2.Data
{
    public class EviHubDbContext : DbContext
    {
        public EviHubDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalWork> ProposalWorks { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<CertificationCategory> CertificationCategories { get; set; }
        public DbSet<Certificationprogress> Certificationprogress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ProposalWork>().HasKey(pw => new { pw.EmpId, pw.ProposalId });

    

            modelBuilder.Entity<ProposalWork>()
                .HasOne(pw => pw.Proposal)
                .WithMany(p => p.ProposalWorks)
                .HasForeignKey(pw => pw.ProposalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProposalWork>()
                .HasOne(pw => pw.Employee)
                .WithMany(e => e.ProposalWorks)

                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    EmpId = 1001,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@evihub.com",
                    Mobile = "9876543210",
                    DOB = new DateTime(1995, 4, 10),
                    Interests = "AI, Reading",
                    DesignationId = 1,
                    ManagerId = null,
                    ProjectId = 1,
                    GenderId = "F",
                    EmergencyContact = "9876543210",
                    IsAdmin = true
                },
                new Employee
                {
                    Id = 2,
                    EmpId = 1002,
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bob.smith@evihub.com",
                    Mobile = "8765432109",
                    DOB = new DateTime(1992, 8, 22),
                    Interests = "ML, Cricket",
                    DesignationId = 2,
                    ManagerId = 1,
                    ProjectId = 2,
                    GenderId = "M",
                    EmergencyContact = "8765432109",
                    IsAdmin = false

                }
                
                );

            //Employee emp1 = new Employee()
            //{ Id=1001, IsAdmin=true };
            //modelBuilder.Entity<Proposal>().HasData(
            //new Proposal
            //{
            //    EmpId = 1,
            //    IsActive = true,
            //    ProposalDescription = "jhsx",
            //    ProposalName = "Test",
            //    ProposalDate = DateTime.Now,
                
            //    Employee  = emp1,
            //    ProposalId = 1,
                

            //}
            //);
        }
        

        }
}
