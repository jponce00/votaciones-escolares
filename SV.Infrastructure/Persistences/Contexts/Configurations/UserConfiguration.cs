using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;
using SV.Utilities.Components;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.UserName)
                .IsUnique();

            builder.Property(e => e.Name)
                .HasMaxLength(200);

            builder.Property(e => e.UserName)
                .HasMaxLength(50);

            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Administrador",
                    UserName = "admin",
                    Password = Encrypt.GetSha256("admin"),
                    RoleId = 1,
                    CreatedYear = DateTime.Now.Year
                });
        }
    }
}
