using Dunamis_API.Data;
using Dunamis_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Persist
{
    public interface IDistribuidoraPersist
    {
        Task<Distribuidora> GetDistribuidoraId(int id);
    }

    public class DistribuidoraPersist : IDistribuidoraPersist
    {
        private readonly DataContext _context;

        public DistribuidoraPersist(DataContext context)
        {
            _context = context;
        }

        public async Task<Distribuidora> GetDistribuidoraId(int id)
        {
            IQueryable<Distribuidora> query = _context.Distribuidora;

            query = query.Where(e => e.Id == id).AsNoTracking().OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}

