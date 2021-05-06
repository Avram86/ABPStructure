using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii.Dto
{
    public class ConsultatieCreateDto
    {
        [Required]
        public DateTime Data { get; set; } = DateTime.Now;
        public string LoculConsultatiei { get; set; } = "Cabinete Cornutiu";
        [Required]
        public string Simptome { get; set; }
        [Required]
        public string Diagnostic { get; set; }
        [Required]
        public string Cod { get; set; }
        [Required]
        public string Prescriptii { get; set; }
        public int? ZileConcediuRecomandate { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? ResourceId { get; set; }

        public bool IsConsultPsihologic { get; set; } = false;
        public string DetaliiPsiholog { get; set; }
    }
}
