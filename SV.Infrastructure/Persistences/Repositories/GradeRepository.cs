using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(SVContext context)
            : base(context)
        {
        }
    }
}
