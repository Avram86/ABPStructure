using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Patients
{
    [System.ComponentModel.DataAnnotations.Schema.Table("pacienti")]
    public class Patient
    {
        [Key]
        public virtual Guid Id { get; set; }

        [NotNull]
        public virtual string UnitateSanitara { get; set; }

        public virtual int NrFisa { get; set; }

        public virtual int? NrVechiFisaArhiva { get; set; }

        public virtual DateTime DataCreariiFisei { get; set; }

        [NotNull]
        public virtual string CNP { get; set; }

        [NotNull]
        public virtual string Nume { get; set; }

        [NotNull]
        public virtual string Prenume { get; set; }

        public virtual DateTime DataNasterii { get; set; }

        public virtual bool Decedat { get; set; }

        public virtual StareCivila StareCivila { get; set; }

        public virtual Sex SexulPacientului { get; set; }

        [NotNull]
        public virtual string Telefon { get; set; }

        [NotNull]
        public virtual string Localitate { get; set; }

        [CanBeNull]
        public virtual string Strada { get; set; }

        public virtual int? NrStrazii { get; set; }

        [CanBeNull]
        public virtual string Ocupatie { get; set; }

        [CanBeNull]
        public virtual string LocMunca { get; set; }

        [CanBeNull]
        public virtual string SchimbariDomiciliu { get; set; }

        [CanBeNull]
        public virtual string SchimbariLocMunca { get; set; }

        [CanBeNull]
        public virtual string AntecedenteHeredo_Colaterale { get; set; }

        [CanBeNull]
        public virtual string AntecedentePersonale { get; set; }

        [CanBeNull]
        public virtual string AntecdenteConditiiMunca { get; set; }

        public virtual GrupeleDeVarstaEnum Grupe { get; set; }

        public Patient()
        {

        }

        public Patient(Guid id, string unitateSanitara, int nrFisa, DateTime dataCreariiFisei, string cNP, string nume, string prenume, DateTime dataNasterii, bool decedat,
            StareCivila stareCivila, Sex sexulPacientului, string telefon, string localitate, string strada, string ocupatie, string locMunca, string schimbariDomiciliu, string schimbariLocMunca, string antecedenteHeredo_Colaterale, string antecedentePersonale, string antecdenteConditiiMunca, GrupeleDeVarstaEnum grupe, int? nrVechiFisaArhiva = null, int? nrStrazii = null)
        {
            Id = id;
            UnitateSanitara = unitateSanitara;
            NrFisa = nrFisa;
            DataCreariiFisei = dataCreariiFisei;
            CNP = cNP;
            Nume = nume;
            Prenume = prenume;
            DataNasterii = dataNasterii;
            Decedat = decedat;
            StareCivila = stareCivila;
            SexulPacientului = sexulPacientului;
            Telefon = telefon;
            Localitate = localitate;
            Strada = strada;
            Ocupatie = ocupatie;
            LocMunca = locMunca;
            SchimbariDomiciliu = schimbariDomiciliu;
            SchimbariLocMunca = schimbariLocMunca;
            AntecedenteHeredo_Colaterale = antecedenteHeredo_Colaterale;
            AntecedentePersonale = antecedentePersonale;
            AntecdenteConditiiMunca = antecdenteConditiiMunca;
            Grupe = grupe;
            NrVechiFisaArhiva = nrVechiFisaArhiva;
            NrStrazii = nrStrazii;
        }
    }
}