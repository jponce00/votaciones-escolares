namespace SV.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public int CreatedYear { get; set; }
    }
}
