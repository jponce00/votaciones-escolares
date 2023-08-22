namespace SV.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Section { get; set; } = null!;

        public int ShiftId { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
