using EviHub.Data.Configurations;
using EviHub.EviHub.Core.Entities;
using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data
{
    public class EviHubDbContext : DbContext
    {
        public EviHubDbContext(DbContextOptions<EviHubDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }


        

        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        
        
        //Master Data
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skills> Skills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api Configurations
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ManagersConfig());
            modelBuilder.ApplyConfiguration(new GendersConfig());
            modelBuilder.ApplyConfiguration(new ProjectsConfig());
            modelBuilder.ApplyConfiguration(new DesignationConfig());
            modelBuilder.ApplyConfiguration(new SkillsConfig());
            modelBuilder.ApplyConfiguration(new CertificationConfig());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());
           

        }





       
    }
}
