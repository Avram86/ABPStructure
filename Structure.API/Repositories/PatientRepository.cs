using MongoDB.Driver;
using Structure.API.ExtensionMethods;
using Structure.API.Models;
using Structure.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMongoCollection<Patient> _pacienti;
        public PatientRepository( IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pacienti = database.GetCollection<Patient>(settings.PacientiCollectionName);
        }
        public async Task DeleteAsync(Guid id)
        {
            await  _pacienti.DeleteOneAsync(p=>p.Id==id);
        }

        public async Task<Patient> GetAsync(Guid id)
        {
            var query = _pacienti.AsQueryable<Patient>().Where(p => p.Id == id);
            return query.FirstOrDefault();
        }

        public IQueryable<Patient> ApplyFilter(
            IQueryable<Patient> query,
            string filterText,
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
            GrupeleDeVarstaEnum? grupe = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UnitateSanitara.Contains(filterText) || e.CNP.Contains(filterText) || e.Nume.Contains(filterText) || e.Prenume.Contains(filterText) || e.Localitate.Contains(filterText) || e.Strada.Contains(filterText) || e.Ocupatie.Contains(filterText) || e.LocMunca.Contains(filterText) || e.SchimbariDomiciliu.Contains(filterText) || e.SchimbariLocMunca.Contains(filterText) || e.AntecedenteHeredo_Colaterale.Contains(filterText) || e.AntecedentePersonale.Contains(filterText) || e.AntecdenteConditiiMunca.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(unitateSanitara), e => e.UnitateSanitara.Contains(unitateSanitara))
                    .WhereIf(nrFisaMin.HasValue, e => e.NrFisa >= nrFisaMin.Value)
                    .WhereIf(nrFisaMax.HasValue, e => e.NrFisa <= nrFisaMax.Value)
                    .WhereIf(nrVechiFisaArhivaMin.HasValue, e => e.NrVechiFisaArhiva >= nrVechiFisaArhivaMin.Value)
                    .WhereIf(nrVechiFisaArhivaMax.HasValue, e => e.NrVechiFisaArhiva <= nrVechiFisaArhivaMax.Value)
                    .WhereIf(dataCreariiFiseiMin.HasValue, e => e.DataCreariiFisei >= dataCreariiFiseiMin.Value)
                    .WhereIf(dataCreariiFiseiMax.HasValue, e => e.DataCreariiFisei <= dataCreariiFiseiMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(cNP), e => e.CNP.Contains(cNP))
                    .WhereIf(!string.IsNullOrWhiteSpace(nume), e => e.Nume.Contains(nume))
                    .WhereIf(!string.IsNullOrWhiteSpace(prenume), e => e.Prenume.Contains(prenume))
                    .WhereIf(dataNasteriiMin.HasValue, e => e.DataNasterii >= dataNasteriiMin.Value)
                    .WhereIf(dataNasteriiMax.HasValue, e => e.DataNasterii <= dataNasteriiMax.Value)
                    .WhereIf(decedat.HasValue, e => e.Decedat == decedat)
                    .WhereIf(stareCivila.HasValue, e => e.StareCivila == stareCivila)
                    .WhereIf(sexulPacientului.HasValue, e => e.SexulPacientului == sexulPacientului)
                    .WhereIf(!string.IsNullOrWhiteSpace(telefon), e => e.Telefon.Contains(telefon))
                    .WhereIf(!string.IsNullOrWhiteSpace(localitate), e => e.Localitate.Contains(localitate))
                    .WhereIf(!string.IsNullOrWhiteSpace(strada), e => e.Strada.Contains(strada))
                    .WhereIf(nrStraziiMin.HasValue, e => e.NrStrazii >= nrStraziiMin.Value)
                    .WhereIf(nrStraziiMax.HasValue, e => e.NrStrazii <= nrStraziiMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(ocupatie), e => e.Ocupatie.Contains(ocupatie))
                    .WhereIf(!string.IsNullOrWhiteSpace(locMunca), e => e.LocMunca.Contains(locMunca))
                    .WhereIf(!string.IsNullOrWhiteSpace(schimbariDomiciliu), e => e.SchimbariDomiciliu.Contains(schimbariDomiciliu))
                    .WhereIf(!string.IsNullOrWhiteSpace(schimbariLocMunca), e => e.SchimbariLocMunca.Contains(schimbariLocMunca))
                    .WhereIf(!string.IsNullOrWhiteSpace(antecedenteHeredo_Colaterale), e => e.AntecedenteHeredo_Colaterale.Contains(antecedenteHeredo_Colaterale))
                    .WhereIf(!string.IsNullOrWhiteSpace(antecedentePersonale), e => e.AntecedentePersonale.Contains(antecedentePersonale))
                    .WhereIf(!string.IsNullOrWhiteSpace(antecdenteConditiiMunca), e => e.AntecdenteConditiiMunca.Contains(antecdenteConditiiMunca))
                    .WhereIf(grupe.HasValue, e => e.Grupe == grupe);
        }
        public async Task<long> GetCountAsync(string filterText = null, string unitateSanitara = null, int? nrFisaMin = null, int? nrFisaMax = null, int? nrVechiFisaArhivaMin = null, 
            int? nrVechiFisaArhivaMax = null, DateTime? dataCreariiFiseiMin = null, DateTime? dataCreariiFiseiMax = null, string cNP = null, string nume = null, string prenume = null, 
            DateTime? dataNasteriiMin = null, DateTime? dataNasteriiMax = null, bool? decedat = null, StareCivila? stareCivila = null, Sex? sexulPacientului = null, string telefon = null, 
            string localitate = null, string strada = null, int? nrStraziiMin = null, int? nrStraziiMax = null, string ocupatie = null, string locMunca = null, 
            string schimbariDomiciliu = null, string schimbariLocMunca = null, string antecedenteHeredo_Colaterale = null, string antecedentePersonale = null, string antecdenteConditiiMunca = null, GrupeleDeVarstaEnum? grupe = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_pacienti.AsQueryable(), filterText, unitateSanitara, nrFisaMin, nrFisaMax, nrVechiFisaArhivaMin, nrVechiFisaArhivaMax,dataCreariiFiseiMin, dataCreariiFiseiMax,
                cNP, nume, prenume, dataNasteriiMin, dataNasteriiMax, decedat, stareCivila, sexulPacientului, telefon, localitate, strada, nrStraziiMin, nrStraziiMax, ocupatie,
                locMunca, schimbariDomiciliu, schimbariLocMunca, antecedenteHeredo_Colaterale, antecedentePersonale, antecdenteConditiiMunca, grupe);

            return query.AsEnumerable().LongCount();
        }

        public async Task<List<Guid>> GetGuidIds()
        {
            var query = _pacienti.AsQueryable().Select(p => p.Id);
            return query.ToList();
        }

        public async Task<List<Patient>> GetListAsync(string filterText = null, string unitateSanitara = null, int? nrFisaMin = null, int? nrFisaMax = null, int? nrVechiFisaArhivaMin = null, 
            int? nrVechiFisaArhivaMax = null, DateTime? dataCreariiFiseiMin = null, DateTime? dataCreariiFiseiMax = null, string cNP = null, string nume = null, string prenume = null, 
            DateTime? dataNasteriiMin = null, DateTime? dataNasteriiMax = null, bool? decedat = null, StareCivila? stareCivila = null, Sex? sexulPacientului = null, string telefon = null, 
            string localitate = null, string strada = null, int? nrStraziiMin = null, int? nrStraziiMax = null, string ocupatie = null, string locMunca = null, string schimbariDomiciliu = null, 
            string schimbariLocMunca = null, string antecedenteHeredo_Colaterale = null, string antecedentePersonale = null, string antecdenteConditiiMunca = null, GrupeleDeVarstaEnum? grupe = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_pacienti.AsQueryable(), filterText, unitateSanitara, nrFisaMin, nrFisaMax, nrVechiFisaArhivaMin, nrVechiFisaArhivaMax, dataCreariiFiseiMin, dataCreariiFiseiMax,
                cNP, nume, prenume, dataNasteriiMin, dataNasteriiMax, decedat, stareCivila, sexulPacientului, telefon, localitate, strada, nrStraziiMin, nrStraziiMax, ocupatie,
                locMunca, schimbariDomiciliu, schimbariLocMunca, antecedenteHeredo_Colaterale, antecedentePersonale, antecdenteConditiiMunca, grupe);

            return query.OrderBy(p=>p.Nume).ToList();
        }

        public Dictionary<string, int> GetMaritalSatusCount()
        {
            var query = _pacienti.AsQueryable();

            var Casatorit = query.Where(p => p.StareCivila == StareCivila.Casatorit).Count();
            var Necasatorit = query.Where(p => p.StareCivila == StareCivila.Necasatorit).Count();
            var Divortat = query.Where(p => p.StareCivila == StareCivila.Divortat).Count();
            var Vaduv = query.Where(p => p.StareCivila == StareCivila.Vaduv).Count();

            var result = new Dictionary<string, int>();

            result.Add("Casatorit", Casatorit);
            result.Add("Necasatorit", Necasatorit);
            result.Add("Divortat", Divortat);
            result.Add("Vaduv", Vaduv);

            return result;
        }

        public async Task<Patient> InsertAsync(Patient patient, bool autoSave)
        {
            _pacienti.InsertOne(patient);
            return _pacienti.AsQueryable().FirstOrDefault(p => p.Id == patient.Id);
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            var pacientToUpdate=await _pacienti.FindOneAndReplaceAsync<Patient>(p=>p.Id==patient.Id, patient);
            return pacientToUpdate;
        }
    }
}
