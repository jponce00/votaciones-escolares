using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Dtos.Vote;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        private readonly SVContext _context;

        public VoteRepository(SVContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VoteDto>> GetResultsAsync(int shiftId)
        {
            var candidates = await _context.Candidates
                .Where(c => c.ShiftId.Equals(shiftId)
                    && c.CreatedYear == DateTime.Now.Year
                    && c.AttachmentData != null)
                .ToListAsync();

            var results = candidates
                .GroupJoin(_context.Votes, c => c.Id, v => v.CandidateId, (c, v) => new VoteDto
                {
                    Team = c.Team,
                    Picture = c.AttachmentData,
                    Votes = v.Count()
                })
                .ToList()
                .OrderBy(v => v.Team);

            return results;
        }
    }
}
