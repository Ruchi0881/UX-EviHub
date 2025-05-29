using EviHub.EviHub.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Data.Configurations
{
    public class LoginConfig: IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(l => l.UserId);
            builder.Property(l => l.UserName).IsRequired().HasMaxLength(100);
            builder.Property(l => l.PasswordHash).IsRequired().HasMaxLength(255);

            builder.HasOne<Employee>()
                .WithOne(e => e.Login)
                .HasForeignKey<Login>(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}

