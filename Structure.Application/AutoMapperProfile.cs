using AutoMapper;
using Structure.Domain.Consultatii;
using Structure.Domain.Consultatii.Dto;
using Structure.Domain.LabelObjects;
using Structure.Domain.LabelObjects.Dto;
using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using Structure.Domain.Resource;
using Structure.Domain.Resource.Dto;
using Structure.Domain.ResourceAppointments;
using Structure.Domain.ResourceAppointments.Dto;
using Structure.Domain.Resources;
using Structure.Domain.Shared;
using Structure.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Application
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<Patient, PatientDto>();

            CreateMap<ConsultatieCreateDto, Consultatie>();
            CreateMap<ConsultatieUpdateDto, Consultatie>();
            CreateMap<Consultatie, ConsultatieDto>();
            CreateMap<ConsultatieWithNavigationProperties, ConsultatieWithNavigationPropertiesDto>();
            CreateMap<Resource, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DoctorName));

            CreateMap<ResourceAppointmentCreateDto, ResourceAppointment>();
            CreateMap<ResourceAppointmentUpdateDto, ResourceAppointment>();
            CreateMap<ResourceAppointment, ResourceAppointmentDto>();
            CreateMap<ResourceAppointmentWithNavigationProperties, ResourceAppointmentWithNavigationPropertiesDto>();

            CreateMap<Patient, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.CNP));

            CreateMap<ResourceCreateDto, Resource>();
            CreateMap<ResourceUpdateDto, Resource>();
            CreateMap<Resource, ResourceDto>();

            CreateMap<Resource, LookupDto<Guid?>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DoctorName));

            CreateMap<LabelObjectCreateDto, Structure.Domain.LabelObjects.LabelObject>();
            CreateMap<LabelObjectUpdateDto, Structure.Domain.LabelObjects.LabelObject>();
            CreateMap<Structure.Domain.LabelObjects.LabelObject, LabelObjectDto>();
        }
    }
}
