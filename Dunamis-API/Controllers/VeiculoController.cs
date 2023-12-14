using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VeiculoController(IVeiculoService veiculoService, IMapper mapper, DataContext context)
        {
            _veiculoService = veiculoService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoId(id);

            if (veiculo == null)
                return NotFound();

            var veiculoDto = _mapper.Map<VeiculoDto>(veiculo);

            return Ok(veiculoDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] DataContext context,
           [FromQuery] int pagina,
            [FromQuery] int totalpagina
           )
        {
            var total = await context.Veiculo
                .CountAsync();
            var data = await context.Veiculo
                .AsNoTracking()
                .Skip((pagina - 1) * totalpagina)
                .Take(totalpagina).ToListAsync();

            return Ok(new
            {
                total,
                data = data
            });
        }


    }
}