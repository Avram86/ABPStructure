using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii
{
    public interface IConsultatieRepository
    {

        Task<ConsultatieWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<ConsultatieWithNavigationProperties>> GetOrderedWithNavigationPropertiesAsync(
            string filterText = null,
            DateTime? dataMin = null,
            DateTime? dataMax = null,
            string loculConsultatiei = null,
            string simptome = null,
            string diagnostic = null,
            string cod = null,
            string prescriptii = null,
            int? zileConcediuRecomandateMin = null,
            int? zileConcediuRecomandateMax = null,
            Guid? patientId = null,
            Guid? resourceId = null,
            bool isConsultPsihologic = false,
            string detaliiPsiholog = null,
            CancellationToken cancellationToken = default);

        Task<List<ConsultatieWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            DateTime? dataMin = null,
            DateTime? dataMax = null,
            string loculConsultatiei = null,
            string simptome = null,
            string diagnostic = null,
            string cod = null,
            string prescriptii = null,
            int? zileConcediuRecomandateMin = null,
            int? zileConcediuRecomandateMax = null,
            Guid? patientId = null,
            Guid? resourceId = null,
            bool isConsultPsihologic = false,
            string detaliiPsiholog = null,
            CancellationToken cancellationToken = default);

        Task<List<Consultatie>> GetListAsync(
            string filterText = null,
            DateTime? dataMin = null,
            DateTime? dataMax = null,
            string loculConsultatiei = null,
            string simptome = null,
            string diagnostic = null,
            string cod = null,
            string prescriptii = null,
            int? zileConcediuRecomandateMin = null,
            int? zileConcediuRecomandateMax = null,
            Guid? patientId = null,
            Guid? resourceId = null,
            bool isConsultPsihologic = false,
            string detaliiPsiholog = null,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
             string filterText = null,
            DateTime? dataMin = null,
            DateTime? dataMax = null,
            string loculConsultatiei = null,
            string simptome = null,
            string diagnostic = null,
            string cod = null,
            string prescriptii = null,
            int? zileConcediuRecomandateMin = null,
            int? zileConcediuRecomandateMax = null,
            bool isConsultPsihologic = false,
            string detaliiPsiholog = null,
            Guid? patientId = null,
            Guid? resourceId = null,
            CancellationToken cancellationToken = default);

        List<Consultatie> GetListForAPatientAsync(Guid patientId);
        Task<List<string>> GetAllCodesInListAsycn();



        Task<Consultatie> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<Consultatie> InsertAsync(Consultatie consultatie, bool autoSave);

        Task<Consultatie> UpdateAsync(Consultatie consultatie);
    
    }
}
