using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetListAsync(
            string filterText = null,
            string unitateSanitara = null,
            int? nrFisaMin = null,
            int? nrFisaMax = null,
            int? nrVechiFisaArhivaMin = null,
            int? nrVechiFisaArhivaMax = null,
            DateTime? dataCreariiFiseiMin = null,
            DateTime? dataCreariiFiseiMax = null,
            string cNP = null,
            string nume = null,
            string prenume = null,
            DateTime? dataNasteriiMin = null,
            DateTime? dataNasteriiMax = null,
            bool? decedat = null,
            StareCivila? stareCivila = null,
            Sex? sexulPacientului = null,
            string telefon = null,
            string localitate = null,
            string strada = null,
            int? nrStraziiMin = null,
            int? nrStraziiMax = null,
            string ocupatie = null,
            string locMunca = null,
            string schimbariDomiciliu = null,
            string schimbariLocMunca = null,
            string antecedenteHeredo_Colaterale = null,
            string antecedentePersonale = null,
            string antecdenteConditiiMunca = null,
            GrupeleDeVarstaEnum? grupe = null,
             CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string filterText = null,
            string unitateSanitara = null,
            int? nrFisaMin = null,
            int? nrFisaMax = null,
            int? nrVechiFisaArhivaMin = null,
            int? nrVechiFisaArhivaMax = null,
            DateTime? dataCreariiFiseiMin = null,
            DateTime? dataCreariiFiseiMax = null,
            string cNP = null,
            string nume = null,
            string prenume = null,
            DateTime? dataNasteriiMin = null,
            DateTime? dataNasteriiMax = null,
            bool? decedat = null,
            StareCivila? stareCivila = null,
            Sex? sexulPacientului = null,
            string telefon = null,
            string localitate = null,
            string strada = null,
            int? nrStraziiMin = null,
            int? nrStraziiMax = null,
            string ocupatie = null,
            string locMunca = null,
            string schimbariDomiciliu = null,
            string schimbariLocMunca = null,
            string antecedenteHeredo_Colaterale = null,
            string antecedentePersonale = null,
            string antecdenteConditiiMunca = null,
            GrupeleDeVarstaEnum? grupe = null,
            CancellationToken cancellationToken = default);

        Dictionary<string, int> GetMaritalSatusCount();
        Task<List<Guid>> GetGuidIds();


        Task<Patient> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<Patient> InsertAsync(Patient patient, bool autoSave);
        Task<Patient> UpdateAsync(Patient patient);
    }
}
