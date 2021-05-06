using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure.Domain.Patients;
using Structure.Domain.Resources;

namespace Structure.Domain.Consultatii
{
    public class ConsultatieWithNavigationProperties
    {
        public Consultatie Consultatie { get; set; }
        public Patient Patient { get; set; }
        public Structure.Domain.Resources.Resource Resource { get; set; }
    }
}
