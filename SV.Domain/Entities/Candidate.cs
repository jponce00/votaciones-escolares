﻿namespace SV.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        public string Team { get; set; } = null!;

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int ShiftId { get; set; }

        public string? AttachmentName { get; set; }

        public byte[]? AttachmentData { get; set; }
    }
}
