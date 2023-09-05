namespace SV.Utilities.Dtos.Candidate
{
    public class CandidateDto
    {
        public string Team { get; set; } = null!;

        public int StudentId { get; set; }

        public int GradeId { get; set; }

        public string? AttachmentName { get; set; }

        public byte[]? AttachmentData { get; set; }
    }
}
