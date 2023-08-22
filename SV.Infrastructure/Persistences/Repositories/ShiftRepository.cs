using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class ShiftRepository : GenericRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(SVContext context)
            : base(context)
        {
        }
    }
}
