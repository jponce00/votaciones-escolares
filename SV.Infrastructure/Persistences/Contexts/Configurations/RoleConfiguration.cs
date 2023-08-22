using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.HasData(
                new Role 
                {
                    Id = 1,
                    Name = "Administrator",
                    CreatedYear = DateTime.Now.Year
                });
        }
    }
}
