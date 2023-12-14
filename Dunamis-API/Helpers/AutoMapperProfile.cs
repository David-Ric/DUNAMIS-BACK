using AutoMapper;
using Dunamis_API.Model;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Model.Dtos.Usuarios;
namespace Dunamis_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserUpdateResquest, Usuario>();
            CreateMap<Motorista, MotoristaDto>();
            CreateMap<Distribuidora, DistribuidoraDto>();
            CreateMap<Veiculo, VeiculoDto>();
            CreateMap<Alocacao, AlocacaoDto>();
        }
    }
}
