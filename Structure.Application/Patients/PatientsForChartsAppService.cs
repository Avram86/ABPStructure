using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application.Patients
{
    public class PatientsForChartsAppService : IPatientsForChartsAppService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsForChartsAppService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<int>> GetPatientsForCharts()
        {
            var Sub_30_ani = await _patientRepository.GetCountAsync(grupe: GrupeleDeVarstaEnum.Sub_30_ani);
            var Intre_31_si_40 = await _patientRepository.GetCountAsync(grupe: GrupeleDeVarstaEnum.Intre_31_si_40);
            var Intre_41_si_50 = await _patientRepository.GetCountAsync(grupe: GrupeleDeVarstaEnum.Intre_41_si_50);
            var Intre_51_si_60 = await _patientRepository.GetCountAsync(grupe: GrupeleDeVarstaEnum.Intre_51_si_60);
            var Intre_61_si_70 = await _patientRepository.GetCountAsync(grupe: GrupeleDeVarstaEnum.Intre_61_si_70);
            var Peste_70 = await _patientRepository.GetCountAsync(grupe: GrupeleDeVarstaEnum.Peste_70);

            List<int> dateVariabileStareCivila = new List<int> { (int)Sub_30_ani, (int)Intre_31_si_40, (int)Intre_41_si_50, (int)Intre_51_si_60, (int)Intre_61_si_70, (int)Peste_70 };

            return dateVariabileStareCivila;
        }
    }
}
