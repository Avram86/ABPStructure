using Structure.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    public interface IPatientsForChartsAppService:IApplicationService
    {
        //for PatientsForChartsController
        Task<List<int>> GetPatientsForCharts();
    }
}
