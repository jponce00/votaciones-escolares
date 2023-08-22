using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasIndex(e => new { e.Name, e.Section }).IsUnique();

            builder.HasData(
                new Grade
                {
                    Id = 1,
                    Name = "1. Primero",
                    Section = "A",
                    ShiftId = 1,
                    CreatedYear = DateTime.Now.Year
                });
        }
    }
}
