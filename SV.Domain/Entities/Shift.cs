namespace SV.Domain.Entities
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
    }
}
