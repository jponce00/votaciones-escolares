using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Dtos.Candidate;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        private readonly SVContext _context;

        public CandidateRepository(SVContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<CandidateDto> GetCandidateWithGradeAsync(int candidateId)
        {
            var query = await _context.Candidates.Join(
                _context.Students,
                c => c.StudentId, s => s.Id,
                (c, s) => new
                {
                    c.Id,
                    c.Team,
                    c.StudentId,
                    s.GradeId,
                    c.AttachmentName,
                    c.AttachmentData
                })
                .FirstOrDefaultAsync(x => x.Id.Equals(candidateId));

            CandidateDto candidateDto = new()
            {
                Team = query!.Team,
                StudentId = query.StudentId,
                GradeId = query.GradeId,
                AttachmentName = query.AttachmentName,
                AttachmentData = query.AttachmentData
            };

            return candidateDto;
        }
    }
}
