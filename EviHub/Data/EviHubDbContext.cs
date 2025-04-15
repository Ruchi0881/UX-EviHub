using EviHub.Data.Configurations;
using EviHub.EviHub.Core.Entities;
using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data
{
    public class EviHubDbContext : DbContext
    {
        public EviHubDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Login> Logins{ get; set; }
        public DbSet <Certification> Certifications { get; set; }
        public DbSet<CertificationCategory> CertificationCategories { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; }
        public DbSet<CertificationProgress> CertificationProgresses{ get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalWork> ProposalWorks { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<ProjectProgress> ProjectProgresses { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        //Master Data
        public DbSet<Certification> Certification { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skills> Skills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api Configurations
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new LoginConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new ManagersConfig());
            modelBuilder.ApplyConfiguration(new GendersConfig());
            modelBuilder.ApplyConfiguration(new ProjectsConfig());
            modelBuilder.ApplyConfiguration(new DesignationConfig());
            modelBuilder.ApplyConfiguration(new SkillsConfig());
            modelBuilder.ApplyConfiguration(new CertificationsConfig());
            modelBuilder.ApplyConfiguration(new ProposalConfig());
            modelBuilder.ApplyConfiguration(new ProposalWorkConfig());
            modelBuilder.ApplyConfiguration(new CertificationCategoryConfig());
            modelBuilder.ApplyConfiguration(new CertificationProgressConfig());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());
            modelBuilder.ApplyConfiguration(new EmployeeSkillConfig());
            modelBuilder.ApplyConfiguration(new ProjectProgressConfig());

        }





       
    }
}
