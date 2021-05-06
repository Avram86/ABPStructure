using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients.Dto
{
    public class PatientCreateDto
    {
        [Required]
        public string UnitateSanitara { get; set; } = "Cabinete Cornutiu";
        public int NrFisa { get; set; }
        public int? NrVechiFisaArhiva { get; set; }
        [Required]
        public DateTime DataCreariiFisei { get; set; } = DateTime.Now;
        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string CNP { get; set; }
        [Required]
        [StringLength(50)]
        public string Nume { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenume { get; set; }
        [Required]
        public DateTime DataNasterii { get; set; }
        public bool Decedat { get; set; } = false;
        public StareCivila StareCivila { get; set; }
        public Sex SexulPacientului { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Localitate { get; set; }
        public string Strada { get; set; }
        public int? NrStrazii { get; set; }
        public string Ocupatie { get; set; }
        public string LocMunca { get; set; }
        [StringLength(150)]
        public string SchimbariDomiciliu { get; set; }
        [StringLength(150)]
        public string SchimbariLocMunca { get; set; }
        [StringLength(250)]
        public string AntecedenteHeredo_Colaterale { get; set; }
        [StringLength(250)]
        public string AntecedentePersonale { get; set; }
        [StringLength(250)]
        public string AntecdenteConditiiMunca { get; set; }
        public GrupeleDeVarstaEnum Grupe { get; set; }
    }
}
