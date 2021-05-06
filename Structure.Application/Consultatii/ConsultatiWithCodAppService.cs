using AutoMapper;
using Microsoft.Extensions.Logging;

using Structure.Domain.Consultatii;
using Structure.Domain.Consultatii.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii
{
    public class ConsultatiWithCodAppService : IConsultatiWithCodAppService
    {
        private readonly IConsultatieRepository _consultatieRepository;
        private readonly IMapper _objectMapper;
        private readonly ILogger<ConsultatiWithCodAppService> _log;

        public ConsultatiWithCodAppService(IConsultatieRepository consultatieRepository, IMapper objectMapper,
            ILogger<ConsultatiWithCodAppService> Log)
        {
            _consultatieRepository = consultatieRepository;
            _objectMapper = objectMapper;
            
            _log = Log;
        }
        public async Task<Dictionary<string, int>> GetConsultatiiWithCod(Guid pacientId)
        {
            var result = new Dictionary<string, int>();

            //recupereaza toate consultatiile din DB
            var consultatii = await _consultatieRepository.GetListAsync();

            //list cu toate codurile din DB
            var listOfCodes = await _consultatieRepository.GetAllCodesInListAsycn();

            foreach (var cod in listOfCodes)
            {
                var newCodeCount = consultatii.Where(c => c.Cod == cod).Count();

                //daca un cod nu exist in dictionar
                if (!result.Keys.Contains(cod))
                {
                    //il introducem
                    result.Add(cod, newCodeCount);
                }
                else
                {
                    //altfel, adunam la nr de aparitii al codului  
                    result[cod] = result[cod] + newCodeCount;
                }
            }
            foreach (var key in result.Keys)
            {
                _log.LogInformation($"Din CONSULTATIIWITHCOD APP SERVICE {key}: {result[key]}");
            }
            return result;
        }
    }
}
