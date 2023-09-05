using SV.Domain.Entities;
using SV.Utilities.Dtos.Candidate;

namespace SV.Infrastructure.Persistences.Interfaces
{
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
        Task<CandidateDto> GetCandidateWithGradeAsync(int candidateId);
    }
}
