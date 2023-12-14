using Dunamis_API.Data;
using Dunamis_API.Model;
using Dunamis_API.Model.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Persist
{
    public interface IVeiculoPersist
    {
        Task<Veiculo> GetVeiculoId(int id);
    }

    public class VeiculoPersist : IVeiculoPersist
    {
        private readonly DataContext _context;

        public VeiculoPersist(DataContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> GetVeiculoId(int id)
        {
            IQueryable<Veiculo> query = _context.Veiculo.Include(v => v.Motorista);

            query = query.Where(e => e.Id == id).AsNoTracking().OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}

