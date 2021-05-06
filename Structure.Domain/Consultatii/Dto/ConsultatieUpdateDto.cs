using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii.Dto
{
    public class ConsultatieUpdateDto
    {
        [Required]
        public DateTime Data { get; set; }
        public string LoculConsultatiei { get; set; }
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
        public bool IsConsultPsihologic { get; set; }
        public string DetaliiPsiholog { get; set; }
    }
}
