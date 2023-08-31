using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SVContext _context;

        public IGradeRepository Grade { get; private set; }

        public IUserRepository User { get; private set; }

        public IShiftRepository Shift { get; private set; }

        public IStudentRepository Student { get; private set; }

        public ICandidateRepository Candidate { get; private set; }

        public IVoteRepository Vote { get; private set; }

        public UnitOfWork(SVContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();

            Grade = new GradeRepository(_context);
            User = new UserRepository(_context);
            Shift = new ShiftRepository(_context);
            Student = new StudentRepository(_context);
            Candidate = new CandidateRepository(_context);
            Vote = new VoteRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
