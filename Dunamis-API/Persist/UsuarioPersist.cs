using Dunamis_API.Data;
using Dunamis_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Persist
{
    public interface IUsuarioPersist
    {
        Task<Usuario> GetUsuarioIdAsync(int id);
    }
    public class UsuarioPersist : IUsuarioPersist
    {
        private readonly DataContext _context;
        public UsuarioPersist(DataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioIdAsync(int id)
        {
            IQueryable<Usuario> query = _context.Usuario;
             

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
