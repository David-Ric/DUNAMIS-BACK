
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dunamis_API.Helpers;
using Dunamis_API.Model.Dtos.Usuarios;
using Dunamis_API.Persist;
using Dunamis_API.Model;
using Dunamis_API.Data;


namespace Dunamis_API.Services
{
    public interface IUserService
    {

        Task<IEnumerable<Usuario>> GetAll();

        Task<Usuario> GetById(int id);
        void Update(int id, UserUpdateResquest model);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuarioPersist _usuarioPersist;

        public UserService(
            DataContext context,
            IUsuarioPersist usuarioPersist,
            IMapper mapper)
        {
            _usuarioPersist = usuarioPersist;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return _context.Usuario;
        }




        public void Update(int id, UserUpdateResquest model)
        {
            var user = getUser(id);

            if (model.Email != user.Email && _context.Usuario.Any(x => x.Email == model.Email))
                throw new AppException("Usuario não encontrado");


            _mapper.Map(model, user);
            _context.Usuario.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Usuario.Remove(user);
            _context.SaveChanges();
        }


        private Usuario getUser(int id)
        {
            var user = _context.Usuario.Find(id);
            if (user == null) throw new KeyNotFoundException("Usuário não encontrado!");
            return user;
        }

        public async Task<Usuario> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioIdAsync(id);
                if (usuario == null) return null;

                var resultado = _mapper.Map<Usuario>(usuario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
