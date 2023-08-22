using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(30);

            builder.HasData(
                new Shift { Id = 1, Name = "Matutina", CreatedYear = DateTime.Now.Year },
                new Shift { Id = 2, Name = "Vespertina", CreatedYear = DateTime.Now.Year });
        }
    }
}
