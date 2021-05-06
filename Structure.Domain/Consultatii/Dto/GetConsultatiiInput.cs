using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii.Dto
{
    public class GetConsultatiiInput
    {
        public string FilterText { get; set; }

        public DateTime? DataMin { get; set; }
        public DateTime? DataMax { get; set; }
        public string LoculConsultatiei { get; set; }
        public string Simptome { get; set; }
        public string Diagnostic { get; set; }
        public string Cod { get; set; }
        public string Prescriptii { get; set; }
        public int? ZileConcediuRecomandateMin { get; set; }
        public int? ZileConcediuRecomandateMax { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? ResourceId { get; set; }
        public bool IsConsultPsihologic { get; set; }
        public string DetaliiPsiholog { get; set; }

        public GetConsultatiiInput()
        {

        }
    }
}
