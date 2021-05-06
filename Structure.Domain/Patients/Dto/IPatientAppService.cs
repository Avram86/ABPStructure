using Structure.Application.Services;
using Structure.Domain.Patients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    public interface IPatientAppService:IApplicationService
    {
        Task<List<PatientDto>> GetListAsync(GetPatientsInput input);

        Task<PatientDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PatientDto> CreateAsync(PatientCreateDto input);

        Task<PatientDto> UpdateAsync(Guid id, PatientUpdateDto input);
        Task<bool> PatientExists(Guid id);
        Task<int> MaxNrFisa();
        Task<Dictionary<string, int>> GetPatientsWithMaritalStatus();
    }
}
