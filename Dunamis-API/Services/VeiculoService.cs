using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Helpers;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Model;
using Dunamis_API.Persist;

namespace Dunamis_API.Services
{
    public interface IVeiculoService
    {
        void Update(int id, VeiculoDto model);
        Task<Veiculo> GetVeiculoId(int id);
    }

    public class VeiculoService : IVeiculoService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IVeiculoPersist _veiculoPersist;

        public VeiculoService(DataContext context, IVeiculoPersist veiculoPersist, IMapper mapper)
        {
            _context = context;
            _veiculoPersist = veiculoPersist;
            _mapper = mapper;
        }

        public void Update(int id, VeiculoDto model)
        {
            var veiculo = GetVeiculo(id);

            if (model.Id != veiculo.Id && _context.Veiculo.Any(x => x.Id == model.Id))
                throw new AppException("Veículo não encontrado");

            _mapper.Map(model, veiculo);
            _context.Veiculo.Update(veiculo);
            _context.SaveChanges();
        }

        private Veiculo GetVeiculo(int id)
        {
            var veiculo = _context.Veiculo.Find(id);
            if (veiculo == null)
                throw new KeyNotFoundException("Veiculo não encontrado!");

            return veiculo;
        }

        public async Task<Veiculo> GetVeiculoId(int id)
        {
            try
            {
                var veiculoDto = await _veiculoPersist.GetVeiculoId(id);
                if (veiculoDto == null)
                    return null;

                var veiculo = _mapper.Map<Veiculo>(veiculoDto);

                return veiculo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
