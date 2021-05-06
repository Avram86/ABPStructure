using MongoDB.Driver;
using Structure.API.ExtensionMethods;
using Structure.API.Models;
using Structure.Domain.ResourceAppointments;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments
{
    public class ResourceAppointmentRepository : IResourceAppointmentRepository
    {
        private readonly IMongoCollection<ResourceAppointment> _resourceAppointments;
        private readonly IMongoCollection<Structure.Domain.Resources.Resource> _doctori;
        public ResourceAppointmentRepository(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _resourceAppointments = database.GetCollection<ResourceAppointment>(settings.ResourceAppointmentCollectionName);
            _doctori = database.GetCollection<Structure.Domain.Resources.Resource>(settings.ResourceCollectionName);
        }
        public async Task DeleteAsync(Guid id)
        {
           await _resourceAppointments.FindOneAndDeleteAsync<ResourceAppointment>(r=>r.Id==id);
        }

        public async Task DeleteIntAsync(int id)
        {
            await _resourceAppointments.FindOneAndDeleteAsync<ResourceAppointment>(r=>r.ResourceAppointmentID==id);
        }

        public async Task<ResourceAppointment> GetAsync(Guid id)
        {
            return (ResourceAppointment)_resourceAppointments.Find<ResourceAppointment>(r=>r.Id==id); 
        }

        public virtual IQueryable<ResourceAppointment> ApplyFilter(
            IQueryable<ResourceAppointment> query,
            string filterText,
            int? appointmentTypeMin = null,
            int? appointmentTypeMax = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null,
            DateTime? endDateMin = null,
            DateTime? endDateMax = null,
            string caption = null,
            string description = null,
            string location = null,
            int? labelMin = null,
            int? labelMax = null,
            int? statusMin = null,
            int? statusMax = null,
            bool? allDay = null,
            string recurrence = null,
            int? resourceIdMin = null,
            int? resourceIdMax = null,
            int? resourceAppointmentIDMin = null,
            int? resourceAppointmentIDMax = null,
            Guid? resorceId = null)
        {
            return query
                 .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Caption.Contains(filterText) || e.Description.Contains(filterText) || e.Location.Contains(filterText) || e.Recurrence.Contains(filterText))
                    .WhereIf(appointmentTypeMin.HasValue, e => e.AppointmentType >= appointmentTypeMin.Value)
                    .WhereIf(appointmentTypeMax.HasValue, e => e.AppointmentType <= appointmentTypeMax.Value)
                    .WhereIf(startDateMin.HasValue, e => e.StartDate >= startDateMin.Value)
                    .WhereIf(startDateMax.HasValue, e => e.StartDate <= startDateMax.Value)
                    .WhereIf(endDateMin.HasValue, e => e.EndDate >= endDateMin.Value)
                    .WhereIf(endDateMax.HasValue, e => e.EndDate <= endDateMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(caption), e => e.Caption.Contains(caption))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description))
                    .WhereIf(!string.IsNullOrWhiteSpace(location), e => e.Location.Contains(location))
                    .WhereIf(labelMin.HasValue, e => e.Label >= labelMin.Value)
                    .WhereIf(labelMax.HasValue, e => e.Label <= labelMax.Value)
                    .WhereIf(statusMin.HasValue, e => e.Status >= statusMin.Value)
                    .WhereIf(statusMax.HasValue, e => e.Status <= statusMax.Value)
                    .WhereIf(allDay.HasValue, e => e.AllDay == allDay)
                    .WhereIf(!string.IsNullOrWhiteSpace(recurrence), e => e.Recurrence.Contains(recurrence))
                    .WhereIf(resourceIdMin.HasValue, e => e.ResourceId >= resourceIdMin.Value)
                    .WhereIf(resourceIdMax.HasValue, e => e.ResourceId <= resourceIdMax.Value)
                    .WhereIf(resourceAppointmentIDMin.HasValue, e => e.ResourceAppointmentID >= resourceAppointmentIDMin.Value)
                    .WhereIf(resourceAppointmentIDMax.HasValue, e => e.ResourceAppointmentID <= resourceAppointmentIDMax.Value)
                    .WhereIf(resorceId != null && resorceId != Guid.Empty, e => e.ResorceId == resorceId);
        }
        public async Task<long> GetCountAsync(string filterText = null, int? appointmentTypeMin = null, int? appointmentTypeMax = null, DateTime? startDateMin = null, DateTime? startDateMax = null, DateTime? endDateMin = null, DateTime? endDateMax = null, string caption = null, string description = null, string location = null, int? labelMin = null, int? labelMax = null, int? statusMin = null, int? statusMax = null, bool? allDay = null, string recurrence = null, int? resourceIdMin = null, int? resourceIdMax = null, int? resourceAppointmentIDMin = null, int? resourceAppointmentIDMax = null, Guid? resorceId = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_resourceAppointments.AsQueryable(),filterText, appointmentTypeMin, appointmentTypeMax, startDateMin, startDateMax, endDateMin, endDateMax, caption, description, 
                location, labelMin, labelMax, statusMin, statusMax, allDay, recurrence, resourceIdMin, resourceIdMax, resourceAppointmentIDMin, resourceAppointmentIDMax, resorceId);

            return query.LongCount();
        }

        public async Task<ResourceAppointment> GetIntAsync(int id)
        {
            return  (ResourceAppointment)_resourceAppointments.Find<ResourceAppointment>(r => r.ResourceAppointmentID == id); 
        }

        public async Task<List<ResourceAppointment>> GetListAsync(string filterText = null, int? appointmentTypeMin = null, int? appointmentTypeMax = null, DateTime? startDateMin = null, DateTime? startDateMax = null, DateTime? endDateMin = null, DateTime? endDateMax = null, string caption = null, string description = null, string location = null, int? labelMin = null, int? labelMax = null, int? statusMin = null, int? statusMax = null, bool? allDay = null, string recurrence = null, int? resourceIdMin = null, int? resourceIdMax = null, int? resourceAppointmentIDMin = null, int? resourceAppointmentIDMax = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_resourceAppointments.AsQueryable(), filterText, appointmentTypeMin, appointmentTypeMax, startDateMin, startDateMax, endDateMin, endDateMax, caption, description,
                location, labelMin, labelMax, statusMin, statusMax, allDay, recurrence, resourceIdMin, resourceIdMax, resourceAppointmentIDMin, resourceAppointmentIDMax);

            return query.ToList();
        }

        public async Task<List<ResourceAppointmentWithNavigationProperties>> GetListWithNavigationPropertiesAsync(string filterText = null, int? appointmentTypeMin = null, int? appointmentTypeMax = null, DateTime? startDateMin = null, DateTime? startDateMax = null, DateTime? endDateMin = null, DateTime? endDateMax = null, string caption = null, string description = null, string location = null, int? labelMin = null, int? labelMax = null, int? statusMin = null, int? statusMax = null, bool? allDay = null, string recurrence = null, int? resourceIdMin = null, int? resourceIdMax = null, int? resourceAppointmentIDMin = null, int? resourceAppointmentIDMax = null, Guid? resorceId = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(_resourceAppointments.AsQueryable(), filterText, appointmentTypeMin, appointmentTypeMax, startDateMin, startDateMax, endDateMin, endDateMax, caption, description,
                 location, labelMin, labelMax, statusMin, statusMax, allDay, recurrence, resourceIdMin, resourceIdMax, resourceAppointmentIDMin, resourceAppointmentIDMax, resorceId);

            var result = query.ToList();
            return result.Select(s => new ResourceAppointmentWithNavigationProperties
            {
                ResourceAppointment = s,
                Resorce=_doctori.AsQueryable().FirstOrDefault(d=>d.Id==s.ResorceId)
            }).ToList() ;
        }

        public async Task<ResourceAppointmentWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = _resourceAppointments.AsQueryable();
            var item = query.FirstOrDefault<ResourceAppointment>(r=>r.Id==id);

            return new ResourceAppointmentWithNavigationProperties 
            {
                ResourceAppointment=item,
                Resorce=_doctori.AsQueryable().FirstOrDefault(d=>d.Id==item.ResorceId)
            };

        }

        public async Task<ResourceAppointment> InsertAsync(ResourceAppointment resourceAppointment, bool autoSave)
        {
             await _resourceAppointments.InsertOneAsync(resourceAppointment);
            var result= _resourceAppointments.AsQueryable().FirstOrDefault(r => r.Id == resourceAppointment.Id);
            result.ResourceAppointmentID = BitConverter.ToInt32(result.Id.ToByteArray(), 0);
            await _resourceAppointments.ReplaceOneAsync(r=>r.Id==result.Id, result);
            result = _resourceAppointments.AsQueryable().FirstOrDefault(r => r.Id == result.Id);
            return result;
        }

        public async Task<ResourceAppointment> UpdateAsync(ResourceAppointment resourceAppointment)
        {
            await _resourceAppointments.ReplaceOneAsync(r => r.Id == resourceAppointment.Id, resourceAppointment);
            return _resourceAppointments.AsQueryable().FirstOrDefault(r => r.Id == resourceAppointment.Id);
        }
    }
}
