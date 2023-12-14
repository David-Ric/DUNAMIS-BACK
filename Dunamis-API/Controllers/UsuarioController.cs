using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Model.Dtos.Usuarios;
using Dunamis_API.Model.Model.Dtos.Usuarios;
using Dunamis_API.Model;
using Dunamis_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private IUserService _userService;
        private IMapper _mapper;

        private readonly IWebHostEnvironment _environment;


        public UsuarioController(
             IUserService userService,
             IMapper mapper,
             DataContext context,
             IWebHostEnvironment environment

                                  )
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromServices] DataContext context,
            [FromQuery] int pagina,
             [FromQuery] int totalpagina
            )
        {
            var total = await context.Usuario.CountAsync();
            var users = await context.Usuario.AsNoTracking().Skip((pagina - 1) * totalpagina).Take(totalpagina).ToListAsync();

            return Ok(new
            {
                total,
                data = users
            });
        }
        [HttpGet("filter")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilter([FromServices] DataContext context,
            [FromQuery] int pagina,
             [FromQuery] int totalpagina,
            [FromQuery] string filter
            )
        {

            var skip = (pagina - 1) * totalpagina;
            var take = totalpagina;

            var data = await context.Usuario
            .AsNoTracking()
                 .Where(e => (e.NomeCompleto.ToLower().Contains(filter.ToLower())))
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var total = await context.Usuario
            .AsNoTracking()
                .Where(e => (e.NomeCompleto.ToLower().Contains(filter.ToLower())))
                .CountAsync();

            return Ok(new
            {
                total,
                data = data
            });


        }
        [HttpGet("filter/status")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilterStatus([FromServices] DataContext context,
            [FromQuery] int pagina,
            [FromQuery] int totalpagina,
            [FromQuery] string filter
            )
        {

            var skip = (pagina - 1) * totalpagina;
            var take = totalpagina;

            var data = await context.Usuario
            .AsNoTracking()
                .Where(e => (e.Status.ToLower().Contains(filter.ToLower())))
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var total = await context.Usuario
            .AsNoTracking()
                .Where(e => (e.Status.ToLower().Contains(filter.ToLower())))
                .CountAsync();

            return Ok(new
            {
                total,
                data = data
            });

        }

        [HttpGet("filter/userName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFilterUserName([FromServices] DataContext context,
           [FromQuery] int pagina,
           [FromQuery] int totalpagina,
           [FromQuery] string filter
           )
        {

            var skip = (pagina - 1) * totalpagina;
            var take = totalpagina;

            var data = await context.Usuario
            .AsNoTracking()
                .Where(e => (e.Username.ToLower().Contains(filter.ToLower())))
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var total = await context.Usuario
            .AsNoTracking()
                .Where(e => (e.Username.ToLower().Contains(filter.ToLower())))
                .CountAsync();

            return Ok(new
            {
                total,
                data = data
            });

        }



        [HttpGet("userName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllName([FromServices] DataContext context,

          [FromQuery] string name

          )
        {

            var users = await context.Usuario
                .AsNoTracking()
                .Where(e => (e.Username.ToLower()
                .Contains(name.ToLower())))
                .OrderBy(e => e.Id)
                .ToListAsync();

            return Ok(users);
        }





        [HttpGet("buscaUsuarios")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsuariosConectados([FromQuery] string searchTerm)
        {
            var usuariosConectados = _context.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                usuariosConectados = usuariosConectados.Where(u =>
                    u.NomeCompleto.Contains(searchTerm) ||
                    u.Username.Contains(searchTerm));
            }

            usuariosConectados = usuariosConectados.OrderBy(u => u.NomeCompleto);

            var usuariosDTO = await usuariosConectados.Select(usuario => new UserDto
            {
                Id = usuario.Id,
                Username = usuario.Username,
                NomeCompleto = usuario.NomeCompleto,
            }).ToListAsync();

            if (usuariosDTO == null || !usuariosDTO.Any())
            {
                return NotFound();
            }

            return usuariosDTO;
        }








        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _userService.GetById(id);
                if (usuario == null) return NoContent();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Usuario não encontrado.");
            }
        }
   

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateResquest model)
        {
            try
            {
                var user = _context.Usuario.FirstOrDefault(x => x.Id == id);

                if (user == null)
                    return NotFound();


                if (model.Email != user.Email && _context.Usuario.Any(x => x.Email == model.Email))
                    return BadRequest("Email já cadastrado na base de dados");


                if (model.Username != user.Username && _context.Usuario.Any(x => x.Username == model.Username))
                    return BadRequest("Usuário já cadastrado na base de dados");

  
                _mapper.Map(model, user);

                _context.Usuario.Update(user);
                _context.SaveChanges();

                return Ok("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
 
                return StatusCode(500, $"Ocorreu um erro ao atualizar o usuário: {ex.Message}");
            }
        }






        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Usuario>>> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário excluído com sucesso!");
        }

    }
}

