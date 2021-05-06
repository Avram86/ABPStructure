using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients.Dto
{
    public class PatientDto
    {
        public string UnitateSanitara { get; set; }
        public int NrFisa { get; set; }
        public int? NrVechiFisaArhiva { get; set; }
        public DateTime DataCreariiFisei { get; set; }
        public string CNP { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public bool Decedat { get; set; }
        public StareCivila StareCivila { get; set; }
        public Sex SexulPacientului { get; set; }
        public string Telefon { get; set; }
        public string Localitate { get; set; }
        public string Strada { get; set; }
        public int? NrStrazii { get; set; }
        public string Ocupatie { get; set; }
        public string LocMunca { get; set; }
        public string SchimbariDomiciliu { get; set; }
        public string SchimbariLocMunca { get; set; }
        public string AntecedenteHeredo_Colaterale { get; set; }
        public string AntecedentePersonale { get; set; }
        public string AntecdenteConditiiMunca { get; set; }
        public GrupeleDeVarstaEnum Grupe { get; set; }
    }
}
