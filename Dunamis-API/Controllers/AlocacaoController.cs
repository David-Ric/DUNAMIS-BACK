using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Model;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Dunamis_API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlocacaoController : ControllerBase
    {
        private readonly IAlocacaoService _alocacaoService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AlocacaoController(IAlocacaoService alocacaoService, IMapper mapper, DataContext context)
        {
            _alocacaoService = alocacaoService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeiculoById(int id)
        {
            var alocacao= await _alocacaoService.GetAlocacaoId(id);

            if (alocacao == null)
                return NotFound();

            var alocacaoDto = _mapper.Map<AlocacaoDto>(alocacao);

            return Ok(alocacaoDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] DataContext context,
           [FromQuery] int pagina,
            [FromQuery] int totalpagina
           )
        {
            var total = await context.Alocacao
                .CountAsync();
            var data = await context.Alocacao
                .Include(a => a.Veiculo)
                .Include(a => a.Veiculo.Motorista)
                .Include(a => a.Distribuidora)
                .AsNoTracking()
                .Skip((pagina - 1) * totalpagina)
                .Take(totalpagina).ToListAsync();

            return Ok(new
            {
                total,
                data = data
            });
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetAll([FromServices] DataContext context,
           [FromQuery] int pagina,
           [FromQuery] int totalpagina,
           [FromQuery] int? tipo,
           [FromQuery] int? veiculoId,
           [FromQuery] int? distribuidoraId)
        {
            var query = context.Alocacao
                .Include(a => a.Veiculo)
                .Include(a => a.Veiculo.Motorista)
                .Include(a => a.Distribuidora)
                .AsNoTracking();

            switch (tipo)
            {
                case 1:
                    if (veiculoId.HasValue)
                        query = query.Where(a => a.VeiculoId == veiculoId);
                    break;
                case 2:
                    if (distribuidoraId.HasValue)
                        query = query.Where(a => a.DistribuidoraId == distribuidoraId);
                    break;

                default:
    
                    return BadRequest("Tipo inválido");
            }

            var total = await query.CountAsync();
            var data = await query
                .Skip((pagina - 1) * totalpagina)
                .Take(totalpagina)
                .ToListAsync();

            return Ok(new
            {
                total,
                data = data
            });
        }



        [HttpPost]
        public async Task<ActionResult<List<Alocacao>>> AddAlocacao(AlocacaoDto model)
        {
            try
            {
                var alocacao = _mapper.Map<Alocacao>(model);

                _context.Alocacao.Add(alocacao);

                await _context.SaveChangesAsync();

                return Ok("Registro criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar alocacao: {ex.Message}");
            }
        }


        [HttpPut("{id}")]

        public IActionResult Update(int id,AlocacaoDto model)
        {

            _alocacaoService.Update(id, model);
            return Ok(new { message = "Registro alterado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Alocacao>>> Delete(int id)
        {
            var alocacao = await _context.Alocacao.FindAsync(id);
            if (alocacao == null)
                return BadRequest("Registro não encontrado");

            _context.Alocacao.Remove(alocacao);
            await _context.SaveChangesAsync();

            return Ok("Registro excluído com sucesso!");
        }


    }
}
