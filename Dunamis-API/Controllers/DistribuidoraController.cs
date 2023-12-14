using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Services;
using Dunamis_API.Helpers;
using Dunamis_API.Model;
using Dunamis_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Dunamis_API.Controllers
{
  // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidoraController : ControllerBase
    {
        private readonly IDistribuidoraService _distribuidoraService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DistribuidoraController(IDistribuidoraService distribuidoraService, IMapper mapper, DataContext context)
        {
            _distribuidoraService = distribuidoraService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistribuidoraById(int id)
        {
            var distribuidora = await _distribuidoraService.GetDistribuidoraId(id);

            if (distribuidora == null)
                return NotFound();

            var distribuidoraDto = _mapper.Map<DistribuidoraDto>(distribuidora);

            return Ok(distribuidoraDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] DataContext context,
           [FromQuery] int pagina,
            [FromQuery] int totalpagina
           )
        {
            var total = await context.Distribuidora
                .CountAsync();
            var data = await context.Distribuidora
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
