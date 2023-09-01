namespace SV.Domain.Entities
{
    public class Vote : BaseEntity
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int ShiftId { get; set; }

        public Shift Shift { get; set; }

        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
