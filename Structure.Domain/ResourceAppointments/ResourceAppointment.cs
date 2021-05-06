using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.ResourceAppointments
{[System.ComponentModel.DataAnnotations.Schema.Table("resourceAppointments")]
    public class ResourceAppointment
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual int AppointmentType { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        [CanBeNull]
        public virtual string Caption { get; set; }

        [CanBeNull]
        public virtual string Description { get; set; }

        [CanBeNull]
        public virtual string Location { get; set; }

        public virtual int? Label { get; set; }

        public virtual int Status { get; set; }

        public virtual bool AllDay { get; set; }

        [CanBeNull]
        public virtual string Recurrence { get; set; }

        public virtual int ResourceId { get; set; }

        public virtual int ResourceAppointmentID { get; set; }
        public Guid? ResorceId { get; set; }

        public ResourceAppointment()
        {

        }

        public ResourceAppointment(Guid id, int appointmentType, DateTime startDate, DateTime endDate, string caption, string description, string location, int status, bool allDay, string recurrence, int resourceId, int resourceAppointment, int? label = null)
        {
            Id = id;
            AppointmentType = appointmentType;
            StartDate = startDate;
            EndDate = endDate;
            Caption = caption;
            Description = description;
            Location = location;
            Status = status;
            AllDay = allDay;
            Recurrence = recurrence;
            ResourceId = resourceId;
            ResourceAppointmentID = resourceAppointment;
            Label = label;
        }
    }
}