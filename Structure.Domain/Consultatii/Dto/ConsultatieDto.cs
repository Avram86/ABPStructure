using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii.Dto
{
    public class ConsultatieDto
    {
        public DateTime Data { get; set; }
        public string LoculConsultatiei { get; set; }
        public string Simptome { get; set; }
        public string Diagnostic { get; set; }
        public string Cod { get; set; }
        public string Prescriptii { get; set; }
        public int? ZileConcediuRecomandate { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? ResourceId { get; set; }
        public bool IsConsultPsihologic { get; set; }
        public string DetaliiPsiholog { get; set; }
    }
}
