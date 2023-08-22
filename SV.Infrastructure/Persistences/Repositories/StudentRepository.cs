using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly SVContext _context;

        public StudentRepository(SVContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<bool> RegisterManyAsync(IEnumerable<Student> students)
        {
            await _context.Students.AddRangeAsync(students);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<bool> RemoveManyAsync(int gradeId)
        {
            var students = await _context.Students
                .Where(s => s.GradeId.Equals(gradeId))
                .ToListAsync();

            _context.Students.RemoveRange(students);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
