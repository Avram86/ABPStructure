using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Consultatii
{
    [System.ComponentModel.DataAnnotations.Schema.Table("consultatii")]
    public class Consultatie
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual DateTime Data { get; set; }

        [CanBeNull]
        public virtual string LoculConsultatiei { get; set; }

        [NotNull]
        public virtual string Simptome { get; set; }

        [NotNull]
        public virtual string Diagnostic { get; set; }

        [NotNull]
        public virtual string Cod { get; set; }

        [NotNull]
        public virtual string Prescriptii { get; set; }

        public virtual int? ZileConcediuRecomandate { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? ResourceId { get; set; }

        public virtual bool IsConsultPsihologic { get; set; }

        public virtual string DetaliiPsiholog { get; set; }

        public Consultatie()
        {

        }

        public Consultatie(Guid id, DateTime data, string loculConsultatiei, string simptome, string diagnostic, string cod, string prescriptii, bool isConsultPsihologic, string detaliiPsiholog
            , int? zileConcediuRecomandate = null)
        {
            Id = id;
            Data = data;
            LoculConsultatiei = loculConsultatiei;
            Simptome = simptome;
            Diagnostic = diagnostic;
            Cod = cod;
            Prescriptii = prescriptii;
            ZileConcediuRecomandate = zileConcediuRecomandate;
            IsConsultPsihologic = isConsultPsihologic;
            DetaliiPsiholog = detaliiPsiholog;
        }
    }
}