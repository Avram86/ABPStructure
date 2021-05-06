using Structure.Domain.Resource.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments.Dto
{
    public class ResourceAppointmentWithNavigationPropertiesDto
    {
        public ResourceAppointmentDto ResourceAppointment { get; set; }

        public ResourceDto Resorce { get; set; }
    }
}
