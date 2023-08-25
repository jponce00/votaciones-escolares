using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(SVContext context)
            : base(context)
        {
        }
    }
}
