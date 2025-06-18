using Evihub.Data.Configurations;
using EviHub.Data.Configurations;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Evihub.Data
{
    public class EviHubDbContext : DbContext
    {
        public EviHubDbContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        // //Fluent Api Configurations
        // modelBuilder.ApplyConfiguration(new EmployeeConfig());
        // modelBuilder.ApplyConfiguration(new ManagersConfig());
        // modelBuilder.ApplyConfiguration(new GendersConfig());
        // modelBuilder.ApplyConfiguration(new ProjectsConfig());
        // modelBuilder.ApplyConfiguration(new DesignationConfig());
        // modelBuilder.ApplyConfiguration(new SkillsConfig());
        // modelBuilder.ApplyConfiguration(new CertificationConfig());
        // modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());


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
        public DbSet<EmployeeSkills> EmployeeSkills { get; set; }

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

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                EmpId = 1001,
                FirstName = "Sai",
                LastName = "Teja",
                Email = "sai.teja@evihub.com",
                Mobile = "9876543210",
                DOB = new DateTime(2000, 1, 1),
                Interests = "AI, Cricket",
                DesignationId = 1, // Make sure this exists in Designation table
                ManagerId = 1, // Top-level employee
                ProjectId = 1, // Must exist in Project table
                GenderId = 1, // Example: 1 = Male
                EmergencyContact = "9876543211",
                IsAdmin = true,
                Username = "kjd",
                Password="jhdc"
            },
            new Employee
            {
                Id = 2,
                EmpId = 1002,
                FirstName = "Anjali",
                LastName = "Sharma",
                Email = "anjali.sharma@evihub.com",
                Mobile = "9123456789",
                DOB = new DateTime(1999, 5, 15),
                Interests = "Machine Learning, Reading",
                DesignationId = 1,
                ManagerId = 1, // Reports to Sai
                ProjectId = 1,
                GenderId = 1, // Example: 2 = Female
                EmergencyContact = "9123456790",
                IsAdmin = false,
                Username = "kjd",
                Password = "jhdc"
            }
            );
            modelBuilder.Entity<Designation>().HasData(
            new Designation
            {
                DesignationId = 1,
                DesignationName = "Intern",
            }
            );
            modelBuilder.Entity<Manager>().HasData(
            new Manager
            {
                ManagerId = 1,
                EmpId = 1001,
                FirstName = "Sai",
                LastName = "Teja",
                Email = "vvsteja23311@gmail.com",
                Mobile = "89387632",
            }
            );
            modelBuilder.Entity<Project>().HasData(
            new Project
            {
                ProjectId = 1,
                ProjectName = "One",
                ProjectDescription = "khdcjkdf",
                IsActive = true,


            }
            );
            modelBuilder.Entity<Gender>().HasData(
            new Gender
            {
                GenderId = 1,
                GenderName = "Male",
            });
        }
    }
}
