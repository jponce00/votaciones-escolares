namespace SV.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
