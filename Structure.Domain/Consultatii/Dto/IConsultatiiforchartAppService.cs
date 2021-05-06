using Structure.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii.Dto
{
    public interface IConsultatiiforchartAppService : IApplicationService
    {
        //for ConsultatiiForChartcontroller
        Task<Dictionary<string, Dictionary<string, int>>> GetAllConsultatii();
        Task<List<ConsultatieDto>> GetConsultatiiForChart(Guid pacientId);
    }
}
