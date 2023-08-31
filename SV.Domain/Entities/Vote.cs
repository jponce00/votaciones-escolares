namespace SV.Domain.Entities
{
    public class Vote : BaseEntity
    {
        public int StudentId { get; set; }

        public int GradeId { get; set; }

        public int ShiftId { get; set; }

        public int CandidateId { get; set; }
    }
}
