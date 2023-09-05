using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Contexts.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(e => e.Team)
                .HasMaxLength(200);

            builder.HasIndex(e => e.StudentId)
                .IsUnique();

            builder.HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Candidate
                {
                    Id = 1,
                    Team = "Planilla #1",
                    ShiftId = 1,
                    StudentId = 1,
                    CreatedYear = DateTime.Now.Year
                });
        }
    }
}
