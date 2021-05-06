using Structure.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    public interface IPatientIdsAppService:IApplicationService
    {
        //for PatientsIdController
        Task<List<Guid>> GetPacientsIds();
    }
}
