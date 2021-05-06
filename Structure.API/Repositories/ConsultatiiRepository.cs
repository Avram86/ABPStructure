using MongoDB.Driver;
using Structure.API.Models;
using Structure.Domain.Consultatii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Structure.Domain.Patients;
using Structure.Domain.Resources;

namespace Structure.Domain.Consultatii
{
    public class ConsultatiiRepository : IConsultatieRepository
    {
        private readonly IMongoCollection<Consultatie> _consultatii;
        private readonly IMongoCollection<Patient> _pacienti;
        private readonly IMongoCollection<Structure.Domain.Resources.Resource> _resources;
        public ConsultatiiRepository(IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DatabaseName);

            _consultatii = database.GetCollection<Consultatie>(dataBaseSettings.ConsultatiiCollectionName);
            _pacienti = database.GetCollection<Patient>(dataBaseSettings.PacientiCollectionName);
            _resources = database.GetCollection<Structure.Domain.Resources.Resource>(dataBaseSettings.ResourceCollectionName);
        }
        public async Task DeleteAsync(Guid id)=>await _consultatii.DeleteOneAsync(c=>c.Id==id);
        
        public async Task<List<string>> GetAllCodesInListAsycn() =>  await (_consultatii.AsQueryable()).Select(c => c.Cod).ToListAsync();

        public async Task<Consultatie> GetAsync(Guid id) => (Consultatie)(await _consultatii.FindAsync(c => c.Id == id));

        public async Task<long> GetCountAsync(string filterText = null, DateTime? dataMin = null, DateTime? dataMax = null, string loculConsultatiei = null, string simptome = null, 
            string diagnostic = null, string cod = null, string prescriptii = null, int? zileConcediuRecomandateMin = null, int? zileConcediuRecomandateMax = null, 
            bool isConsultPsihologic = false, string detaliiPsiholog = null, Guid? patientId = null, Guid? resourceId = null, CancellationToken cancellationToken=default)
        {
            var query = GetFilter(_consultatii.AsQueryable(), filterText, dataMin, dataMax, loculConsultatiei, simptome, diagnostic, cod, prescriptii, 
                zileConcediuRecomandateMin, zileConcediuRecomandateMax, isConsultPsihologic, detaliiPsiholog, patientId, resourceId);

            return (query.AsQueryable<Consultatie>()).LongCount();

        }

        public IQueryable<Consultatie> GetFilter(IQueryable<Consultatie> query,
            string filterText = null, DateTime? dataMin = null, DateTime? dataMax = null, string loculConsultatiei = null, string simptome = null,
            string diagnostic = null, string cod = null, string prescriptii = null, int? zileConcediuRecomandateMin = null, int? zileConcediuRecomandateMax = null,
            bool isConsultPsihologic = false, string detaliiPsiholog = null, Guid? patientId = null, Guid? resourceId = null, CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrWhiteSpace(filterText))
                query = query.Where(e => e.LoculConsultatiei.Contains(filterText) || e.Simptome.Contains(filterText) || e.Diagnostic.Contains(filterText) || e.Cod.Contains(filterText) || e.Prescriptii.Contains(filterText));
            if (dataMin.HasValue)
                query.Where(e => e.Data >= dataMin);
            if (dataMax.HasValue)
                query.Where(e => e.Data <= dataMax);
            if (!string.IsNullOrWhiteSpace(loculConsultatiei))
                query.Where(e => e.LoculConsultatiei.Contains(loculConsultatiei));
            if (!string.IsNullOrWhiteSpace(simptome))
                query.Where(e => e.Simptome.Contains(simptome));
            if (!string.IsNullOrWhiteSpace(diagnostic))
                query.Where(e => e.Diagnostic.Contains(diagnostic));
            if (!string.IsNullOrWhiteSpace(cod))
                query.Where(e => e.Cod.Contains(cod));
            if (!string.IsNullOrWhiteSpace(prescriptii))
                query.Where(e => e.Prescriptii.Contains(prescriptii));
            if (isConsultPsihologic == true)
                query.Where(e => e.IsConsultPsihologic == isConsultPsihologic);
            if (!string.IsNullOrWhiteSpace(detaliiPsiholog))
                query.Where(e=>e.DetaliiPsiholog.Contains(detaliiPsiholog));
            if (zileConcediuRecomandateMin.HasValue)
                query.Where(e => e.ZileConcediuRecomandate >= zileConcediuRecomandateMin.Value);
            if (zileConcediuRecomandateMax.HasValue)
                query.Where(e => e.ZileConcediuRecomandate >= zileConcediuRecomandateMax.Value);
            if (patientId != null && patientId != Guid.Empty)
                query.Where(e=>e.PatientId==patientId);
            if (resourceId != null && resourceId != Guid.Empty)
                query.Where(e => e.ResourceId == resourceId);
            
            
            return query;
        }
        public async Task<List<Consultatie>> GetListAsync(string filterText = null, DateTime? dataMin = null, DateTime? dataMax = null, string loculConsultatiei = null, string simptome = null,
            string diagnostic = null, string cod = null, string prescriptii = null, int? zileConcediuRecomandateMin = null, int? zileConcediuRecomandateMax = null, Guid? patientId = null, 
            Guid? resourceId = null, bool isConsultPsihologic = false, string detaliiPsiholog = null, CancellationToken cancellationToken = default)
        {
            var query = GetFilter(_consultatii.AsQueryable(), filterText, dataMin, dataMax, loculConsultatiei, simptome, diagnostic, cod, prescriptii,
               zileConcediuRecomandateMin, zileConcediuRecomandateMax, isConsultPsihologic, detaliiPsiholog, patientId, resourceId);

            return (query.AsQueryable<Consultatie>()).OrderBy(c=>c.Data).ToList();
        }

        public List<Consultatie> GetListForAPatientAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ConsultatieWithNavigationProperties>> GetListWithNavigationPropertiesAsync(string filterText = null, DateTime? dataMin = null, DateTime? dataMax = null, 
            string loculConsultatiei = null, string simptome = null, string diagnostic = null, string cod = null, string prescriptii = null, int? zileConcediuRecomandateMin = null, 
            int? zileConcediuRecomandateMax = null, Guid? patientId = null, Guid? resourceId = null, bool isConsultPsihologic = false, string detaliiPsiholog = null, 
            CancellationToken cancellationToken = default)
        {
            var query = GetFilter(_consultatii.AsQueryable(), filterText, dataMin, dataMax, loculConsultatiei, simptome, diagnostic, cod, prescriptii,
               zileConcediuRecomandateMin, zileConcediuRecomandateMax, isConsultPsihologic, detaliiPsiholog, patientId, resourceId);

            var consultatii =  query.AsQueryable<Consultatie>();
            var pacienti = await (_pacienti.AsQueryable()).ToListAsync();
            var doctori =await ( _resources.AsQueryable()).ToListAsync();

            var result = consultatii.Select( s => new ConsultatieWithNavigationProperties
            {
                Consultatie = s,
                Patient =  pacienti.Where(p => p.Id == patientId).FirstOrDefault(),
                Resource =  doctori.FirstOrDefault(r => r.Id == resourceId)
            }).ToList();

            return result;

        }

        public async Task<List<ConsultatieWithNavigationProperties>> GetOrderedWithNavigationPropertiesAsync(string filterText = null, DateTime? dataMin = null, DateTime? dataMax = null, 
            string loculConsultatiei = null, string simptome = null, string diagnostic = null, string cod = null, string prescriptii = null, int? zileConcediuRecomandateMin = null,
            int? zileConcediuRecomandateMax = null, Guid? patientId = null, Guid? resourceId = null, bool isConsultPsihologic = false, string detaliiPsiholog = null, 
            CancellationToken cancellationToken = default)
        {
            var query = GetFilter(_consultatii.AsQueryable(), filterText, dataMin, dataMax, loculConsultatiei, simptome, diagnostic, cod, prescriptii,
               zileConcediuRecomandateMin, zileConcediuRecomandateMax, isConsultPsihologic, detaliiPsiholog, patientId, resourceId);

            var consultatii = query.OrderBy(c => c.Data).AsQueryable<Consultatie>();
            var pacienti =await ( _pacienti.AsQueryable()).ToListAsync();
            var doctori = await (_resources.AsQueryable()).ToListAsync();

            var result = consultatii.Select(s => new ConsultatieWithNavigationProperties
            {
                Consultatie = s,
                Patient = pacienti.Where(p => p.Id == patientId).FirstOrDefault(),
                Resource = doctori.FirstOrDefault(r => r.Id == resourceId)
            }).ToList();

            return result;
        }

        public async Task<ConsultatieWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = _consultatii.AsQueryable();
            var consultatie =await query.FirstOrDefaultAsync(c => c.Id == id);
            var pacienti = _pacienti.AsQueryable();
            var doctori = _resources.AsQueryable();

            return new ConsultatieWithNavigationProperties
            {
                Consultatie = consultatie,
                Patient = pacienti.FirstOrDefault(p => p.Id == consultatie.PatientId),
                Resource = doctori.FirstOrDefault(d => d.Id == consultatie.ResourceId)
            };
        }

        public async Task<Consultatie> InsertAsync(Consultatie consultatie, bool autoSave)
        {
            await _consultatii.InsertOneAsync(consultatie);
            var query = _consultatii.AsQueryable();
            return await query.FirstOrDefaultAsync(c=>c.Id==consultatie.Id);
        }

        public async  Task<Consultatie> UpdateAsync(Consultatie consultatie)
        {
          await  _consultatii.ReplaceOneAsync(c => c.Id == consultatie.Id, consultatie);
            return await (_consultatii.AsQueryable()).FirstOrDefaultAsync(c => c.Id == consultatie.Id);
        }
    }
}
