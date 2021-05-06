using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients.Dto
{
    public class GetPatientsInput
    {
        public string FilterText { get; set; }

        public string UnitateSanitara { get; set; }
        public int? NrFisaMin { get; set; }
        public int? NrFisaMax { get; set; }
        public int? NrVechiFisaArhivaMin { get; set; }
        public int? NrVechiFisaArhivaMax { get; set; }
        public DateTime? DataCreariiFiseiMin { get; set; }
        public DateTime? DataCreariiFiseiMax { get; set; }
        public string CNP { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime? DataNasteriiMin { get; set; }
        public DateTime? DataNasteriiMax { get; set; }
        public bool? Decedat { get; set; }
        public StareCivila? StareCivila { get; set; }
        public Sex? SexulPacientului { get; set; }

        public string Telefon { get; set; }
        public string Localitate { get; set; }
        public string Strada { get; set; }
        public int? NrStraziiMin { get; set; }
        public int? NrStraziiMax { get; set; }
        public string Ocupatie { get; set; }
        public string LocMunca { get; set; }
        public string SchimbariDomiciliu { get; set; }
        public string SchimbariLocMunca { get; set; }
        public string AntecedenteHeredo_Colaterale { get; set; }
        public string AntecedentePersonale { get; set; }
        public string AntecdenteConditiiMunca { get; set; }
        public GrupeleDeVarstaEnum? Grupe { get; set; }

        public GetPatientsInput()
        {

        }
    }
}
