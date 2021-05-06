using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments
{
    public interface IResourceAppointmentRepository
    {
        Task<ResourceAppointmentWithNavigationProperties> GetWithNavigationPropertiesAsync(
               Guid id,
               CancellationToken cancellationToken = default
                );

        Task<List<ResourceAppointmentWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
           string filterText = null,
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
           Guid? resorceId = null,
            CancellationToken cancellationToken = default
        );

        Task<List<ResourceAppointment>> GetListAsync(
                    string filterText = null,
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
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
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
            Guid? resorceId = null,
            CancellationToken cancellationToken = default);

        Task<ResourceAppointment> GetIntAsync(int id);
        Task DeleteIntAsync(int id);

        Task<ResourceAppointment> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<ResourceAppointment> InsertAsync(ResourceAppointment resourceAppointment, bool autoSave);
        Task<ResourceAppointment> UpdateAsync(ResourceAppointment resourceAppointment);
    }
}
