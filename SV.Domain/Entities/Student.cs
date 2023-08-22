namespace SV.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; } = null!;

        public int GradeId { get; set; }
    }
}
