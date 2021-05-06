using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments
{
    public class ResourceAppointmentWithNavigationProperties
    {
        public ResourceAppointment ResourceAppointment { get; set; }

        public Structure.Domain.Resources.Resource Resorce { get; set; }
    }
}
