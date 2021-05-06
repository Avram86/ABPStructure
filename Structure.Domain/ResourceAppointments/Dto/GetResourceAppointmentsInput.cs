using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments.Dto
{
    public class GetResourceAppointmentsInput
    {
        public string FilterText { get; set; }

        public int? AppointmentTypeMin { get; set; }
        public int? AppointmentTypeMax { get; set; }
        public DateTime? StartDateMin { get; set; }
        public DateTime? StartDateMax { get; set; }
        public DateTime? EndDateMin { get; set; }
        public DateTime? EndDateMax { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? LabelMin { get; set; }
        public int? LabelMax { get; set; }
        public int? StatusMin { get; set; }
        public int? StatusMax { get; set; }
        public bool? AllDay { get; set; }
        public string Recurrence { get; set; }
        public int? ResourceIdMin { get; set; }
        public int? ResourceIdMax { get; set; }
        public int? ResourceAppointmentIDMin { get; set; }
        public int? ResourceAppointmentIDMax { get; set; }
        public Guid? ResorceId { get; set; }

        public GetResourceAppointmentsInput()
        {

        }
    }
}