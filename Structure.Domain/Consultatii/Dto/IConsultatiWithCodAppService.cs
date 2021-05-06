using Structure.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii
{
    public interface IConsultatiWithCodAppService : IApplicationService
    {
        //for ConsultatiiWithCodController
        Task<Dictionary<string, int>> GetConsultatiiWithCod(Guid pacientId);
    }
}
