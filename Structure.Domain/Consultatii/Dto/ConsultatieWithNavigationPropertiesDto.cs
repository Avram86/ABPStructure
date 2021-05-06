using Structure.Domain.Patients.Dto;
using Structure.Domain.Resource.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii.Dto
{
    public class ConsultatieWithNavigationPropertiesDto
    {
        public ConsultatieDto Consultatie { get; set; }

        public PatientDto Patient { get; set; }
        public ResourceDto Resource { get; set; }
    }
}
