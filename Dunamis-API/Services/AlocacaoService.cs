using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Helpers;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Model;
using Dunamis_API.Persist;

namespace Dunamis_API.Services
{
    public interface IAlocacaoService
    {
        void Update(int id, AlocacaoDto model);
        Task<Alocacao> GetAlocacaoId(int id);
    }

    public class AlocacaoService : IAlocacaoService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IAlocacaoPersist _alocacaoPersist;

        public AlocacaoService(DataContext context, IAlocacaoPersist alocacaoPersist, IMapper mapper)
        {
            _context = context;
            _alocacaoPersist = alocacaoPersist;
            _mapper = mapper;
        }

        public void Update(int id, AlocacaoDto model)
        {
            var alocacao= GetAlocacao(id);

            if (model.Id != alocacao.Id && _context.Alocacao.Any(x => x.Id == model.Id))
                throw new AppException("Alocação não encontrada");

            _mapper.Map(model, alocacao);
            _context.Alocacao.Update(alocacao);
            _context.SaveChanges();
        }

        private Alocacao GetAlocacao(int id)
        {
            var alocacao = _context.Alocacao.Find(id);
            if (alocacao == null)
                throw new KeyNotFoundException("Alocaçao não encontrada!");

            return alocacao;
        }

        public async Task<Alocacao> GetAlocacaoId(int id)
        {
            try
            {
                var alocacaoDto = await _alocacaoPersist.GetAlocacaoId(id);
                if (alocacaoDto == null)
                    return null;

                var alocacao = _mapper.Map<Alocacao>(alocacaoDto);

                return alocacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
