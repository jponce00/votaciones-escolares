using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(200);

            builder.HasIndex(e => new { e.Name, e.GradeId })
                .IsUnique();

            builder.HasData(
                new Candidate
                {
                    Id = 1,
                    Name = "JAIRO JOSUE PONCE VILLALTA",
                    Team = "Planilla #1",
                    ShiftId = 1,
                    GradeId = 1,
                    CreatedYear = DateTime.Now.Year
                });
        }
    }
}
