using AutoMapper;
using Dunamis_API.Data;
using Dunamis_API.Helpers;
using Dunamis_API.Model;
using Dunamis_API.Model.Dtos;
using Dunamis_API.Persist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dunamis_API.Services
{
    public interface IDistribuidoraService
    {
        void Update(int id, DistribuidoraDto model);
        Task<Distribuidora> GetDistribuidoraId(int id);
    }

    public class DistribuidoraService : IDistribuidoraService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IDistribuidoraPersist _distribuidoraPersist;

        public DistribuidoraService(DataContext context, IDistribuidoraPersist distribuidoraPersist, IMapper mapper)
        {
            _context = context;
            _distribuidoraPersist = distribuidoraPersist;
            _mapper = mapper;
        }

        public void Update(int id, DistribuidoraDto model)
        {
            var distribuidora = GetDistribuidora(id);

            if (model.Id != distribuidora.Id && _context.Distribuidora.Any(x => x.Id == model.Id))
                throw new AppException("Distribuidora não encontrada");

            _mapper.Map(model, distribuidora);
            _context.Distribuidora.Update(distribuidora);
            _context.SaveChanges();
        }

        private Distribuidora GetDistribuidora(int id)
        {
            var distribuidora = _context.Distribuidora.Find(id);
            if (distribuidora == null)
                throw new KeyNotFoundException("Distribuidora não encontrada!");

            return distribuidora;
        }

        public async Task<Distribuidora> GetDistribuidoraId(int id)
        {
            try
            {
                var distribuidoraDto = await _distribuidoraPersist.GetDistribuidoraId(id);
                if (distribuidoraDto == null)
                    return null;

                var distribuidora = _mapper.Map<Distribuidora>(distribuidoraDto);

                return distribuidora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
