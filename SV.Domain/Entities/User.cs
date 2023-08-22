namespace SV.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }
    }
}
