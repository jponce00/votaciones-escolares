using SV.Domain.Entities;
using SV.Utilities.Dtos.Vote;

namespace SV.Infrastructure.Persistences.Interfaces
{
    public interface IVoteRepository : IGenericRepository<Vote>
    {
        Task<IEnumerable<VoteDto>> GetResultsAsync(int shiftId);
    }
}
