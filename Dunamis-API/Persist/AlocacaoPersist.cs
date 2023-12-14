using Dunamis_API.Data;
using Dunamis_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Persist
{
    public interface IAlocacaoPersist
    {
        Task<Alocacao> GetAlocacaoId(int id);
    }

    public class AlocacaoPersist : IAlocacaoPersist
    {
        private readonly DataContext _context;

        public AlocacaoPersist(DataContext context)
        {
            _context = context;
        }

        public async Task<Alocacao> GetAlocacaoId(int id)
        {
            IQueryable<Alocacao> query = _context.Alocacao
                .Include(a => a.Veiculo)
                .Include(a => a.Veiculo.Motorista)
                .Include(a => a.Distribuidora);

            query = query.Where(e => e.Id == id).AsNoTracking().OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
