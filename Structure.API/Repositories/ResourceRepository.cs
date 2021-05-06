using MongoDB.Driver;
using Structure.API.ExtensionMethods;
using Structure.API.Models;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.Resources
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IMongoCollection<Resource> _doctori;
        public ResourceRepository(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _doctori = database.GetCollection<Resource>(settings.ResourceCollectionName);
        }
        public async Task DeleteAsync(Guid id)
        {
             await _doctori.DeleteOneAsync(d=>d.Id==id);
        }

        public async Task<Guid> FindByIntId(int Id)
        {
            return _doctori.AsQueryable().Where(r => r.ResourceId == Id).Select(d=>d.Id).FirstOrDefault();
            
        }

        public async Task<Resource> GetAsync(Guid id)
        {
            var item = _doctori.AsQueryable().FirstOrDefault(d=>d.Id==id);
            return item;
        }

        public  virtual IQueryable<Resource> ApplyFilter(
            IQueryable<Resource> query,
            string filterText,
            string doctorName = null,
            TextCss? textCss = null,
            BackgroundCss? backgroundCss = null,
            int? groupIdMin = null,
            int? groupIdMax = null,
            bool? isGroup = null,
            Specializari? name = null,
            int? resourceIdMin = null,
            int? resourceIdMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DoctorName.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(doctorName), e => e.DoctorName.Contains(doctorName))
                    .WhereIf(textCss.HasValue, e => e.TextCss == textCss)
                    .WhereIf(backgroundCss.HasValue, e => e.BackgroundCss == backgroundCss)
                    .WhereIf(groupIdMin.HasValue, e => e.GroupId >= groupIdMin.Value)
                    .WhereIf(groupIdMax.HasValue, e => e.GroupId <= groupIdMax.Value)
                    .WhereIf(isGroup.HasValue, e => e.IsGroup == isGroup)
                    .WhereIf(name.HasValue, e => e.Name == name)
                    .WhereIf(resourceIdMin.HasValue, e => e.ResourceId >= resourceIdMin.Value)
                    .WhereIf(resourceIdMax.HasValue, e => e.ResourceId <= resourceIdMax.Value);
        }


        public async Task<long> GetCountAsync(string filterText = null, string doctorName = null, TextCss? textCss = null, BackgroundCss? backgroundCss = null, int? groupIdMin = null, int? groupIdMax = null, bool? isGroup = null, Specializari? name = null, int? resourceIdMin = null, int? resourceIdMax = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_doctori.AsQueryable(), filterText, doctorName, textCss, backgroundCss, groupIdMin, groupIdMax, isGroup, name, resourceIdMin, resourceIdMax);
            return query.LongCount();
        }

        public async Task<List<Resource>> GetListAsync(string filterText = null, string doctorName = null, TextCss? textCss = null, BackgroundCss? backgroundCss = null, int? groupIdMin = null, int? groupIdMax = null, bool? isGroup = null, Specializari? name = null, int? resourceIdMin = null, int? resourceIdMax = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_doctori.AsQueryable(), filterText, doctorName, textCss, backgroundCss, groupIdMin, groupIdMax, isGroup, name, resourceIdMin, resourceIdMax);
            var doctori = query.AsQueryable().OrderBy(d => d.Name).ToList();

            return doctori;
        }

        public async Task<Resource> InsertAsync(Resource resource, bool autoSave)
        {
            await _doctori.InsertOneAsync(resource);
            var result = _doctori.AsQueryable().FirstOrDefault(r=>r.Id==resource.Id);
            result.ResourceId = BitConverter.ToInt32(result.Id.ToByteArray(), 0);
             _doctori.ReplaceOne(d=>d.Id==result.Id, result);
            return _doctori.AsQueryable().FirstOrDefault(r => r.Id == result.Id);

        }

        public async Task<Resource> UpdateAsync(Resource resource)
        {
            await _doctori.ReplaceOneAsync(r => r.Id == resource.Id, resource);
            return _doctori.AsQueryable().FirstOrDefault(r => r.Id == resource.Id);
        }
    }
}
