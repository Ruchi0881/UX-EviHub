using EviHub2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EviHub2.Data.Configurations
{
    public class EmployeeConfig :   IEntityTypeConfiguration<Employee>
    {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.EmpId).IsRequired().HasMaxLength(50);
                builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Email).IsRequired().HasMaxLength(200);
                builder.Property(e => e.Mobile).IsRequired().HasMaxLength(15);
                builder.Property(e => e.Interests).HasMaxLength(500);
                builder.Property(e => e.EmergencyContact).IsRequired().HasMaxLength(15);
                
            }
    }
}
