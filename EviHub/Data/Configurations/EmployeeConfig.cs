using EviHub.EviHub.Core.Entities;
using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EviHub.Data.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmpId);
            //builder.Property(e => e.EmpId).IsRequired().HasMaxLength(50);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Mobile).IsRequired().HasMaxLength(15);
            builder.Property(e => e.Interests).HasMaxLength(500);
            builder.Property(e => e.EmergencyContact).IsRequired().HasMaxLength(15);
            builder.Property(e => e.IsAdmin).HasDefaultValue(false);

            builder.HasOne(e=>e.Designation)
                .WithMany(d=>d.Employees)
                .HasForeignKey(e => e.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(e => e.Manager)
            //    .WithMany(m => m.EmployeesUnderManager)
            //    .HasForeignKey(e => e.ManagerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e=>e.Gender)
                .WithMany(g=>g.Employees)
                .HasForeignKey(e => e.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e=>e.Login )
                .WithOne(l => l.Employee)
                .HasForeignKey<Login>(l => l.EmpId)
                .OnDelete(DeleteBehavior.Restrict);


            //builder.HasMany(x=>x.EmployeesUnderManager).WithOne(x=>x.Manager)


        }

    }       
}
