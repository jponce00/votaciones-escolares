namespace SV.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Team { get; set; } = null!;

        public int GradeId { get; set; }

        public int ShiftId { get; set; }

        public string? AttachmentName { get; set; }

        public byte[]? AttachmentData { get; set; }
    }
}
