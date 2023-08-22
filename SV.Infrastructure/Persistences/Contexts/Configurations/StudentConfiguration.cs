using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(200);

            builder.HasIndex(e => new { e.Name, e.GradeId })
                .IsUnique();
        }
    }
}
