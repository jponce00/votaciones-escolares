using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using System.Reflection;

namespace SV.Infrastructure.Persistences.Contexts
{
    public class SVContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SistemaVotaciones;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
