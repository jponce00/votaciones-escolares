using SV.Domain.Entities;

namespace SV.Infrastructure.Persistences.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<bool> RegisterManyAsync(IEnumerable<Student> students);

        Task<bool> RemoveManyAsync(int gradeId);
    }
}
