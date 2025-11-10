using AutoMapper;
using BootcampProject.Business.DTOs.Requests;
using BootcampProject.Business.DTOs.Responses;
using BootcampProject.Entities;

namespace BootcampProject.Business.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationResponse>()
                .ForMember(dest => dest.ApplicantFullName, opt => opt.MapFrom(src => $"{src.Applicant.FirstName} {src.Applicant.LastName}"))
                .ForMember(dest => dest.BootcampName, opt => opt.MapFrom(src => src.Bootcamp.Name));

            CreateMap<CreateBootcampRequest, Application>();
            CreateMap<UpdateBootcampRequest, Application>();
        }
    }
}
