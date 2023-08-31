namespace SV.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGradeRepository Grade { get; }

        IUserRepository User { get; }

        IShiftRepository Shift { get; }

        IStudentRepository Student { get; }

        ICandidateRepository Candidate { get; }

        IVoteRepository Vote { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
