using EviHub.EviHub.Core.Entities.MasterData;
using Evihub.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EviHub.Data.Configurations;
using EviHub.Models.Entities;

namespace Evihub.Data
{
    public class EviHubDbContext : DbContext
    {
        public EviHubDbContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Fluent Api Configurations
        //    modelBuilder.ApplyConfiguration(new EmployeeConfig());
        //    modelBuilder.ApplyConfiguration(new ManagersConfig());
        //    modelBuilder.ApplyConfiguration(new GendersConfig());
        //    modelBuilder.ApplyConfiguration(new ProjectsConfig());
        //    modelBuilder.ApplyConfiguration(new DesignationConfig());
        //    modelBuilder.ApplyConfiguration(new SkillsConfig());
        //    modelBuilder.ApplyConfiguration(new CertificationConfig());
        //    modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());


        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalWork> ProposalWorks { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<CertificationCategory> CertificationCategories { get; set; }
        public DbSet<Certificationprogress> Certificationprogress { get; set; }

        //public DbSet<Employee> Employees { get; set; }




        public DbSet<EmployeeProject> EmployeeProjects { get; set; }



        //Master Data
        //public DbSet<Certification> Certifications { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<EmployeeSkills>   EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ProposalWork>().HasKey(pw => new { pw.EmpId, pw.ProposalId });
            //Fluent Api Configurations
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ManagersConfig());
            modelBuilder.ApplyConfiguration(new GendersConfig());
            modelBuilder.ApplyConfiguration(new ProjectsConfig());
            modelBuilder.ApplyConfiguration(new DesignationConfig());
            modelBuilder.ApplyConfiguration(new SkillsConfig());
            modelBuilder.ApplyConfiguration(new CertificationConfig());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());



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
        

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
                  
            //        EmpId = 1001,
            //        FirstName = "Alice",
            //        LastName = "Johnson",
            //        Email = "alice.johnson@evihub.com",
            //        Mobile = "9876543210",
            //        DOB = new DateTime(1995, 4, 10),
            //        Interests = "AI, Reading",
            //        DesignationId = 1,
            //        ManagerId = null,
            //        ProjectId = 1,
            //        GenderId = 1,
            //        EmergencyContact = "9876543210",
            //        IsAdmin = true
            //    },
            //    new Employee
            //    {
                
            //        EmpId = 1002,
            //        FirstName = "Bob",
            //        LastName = "Smith",
            //        Email = "bob.smith@evihub.com",
            //        Mobile = "8765432109",
            //        DOB = new DateTime(1992, 8, 22),
            //        Interests = "ML, Cricket",
            //        DesignationId = 2,
            //        ManagerId = 1,
            //        ProjectId = 2,
            //        GenderId = 1,
            //        EmergencyContact = "8765432109",
            //        IsAdmin = false

            //    }
                
                

            
        }
        

        }
}
