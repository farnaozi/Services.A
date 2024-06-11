using AutoMapper;
using Services.A.Core.Dtos;
using Services.A.Core.Models;

namespace Services.A.Core.Profiles
{
    public class TemplateServiceProfiles : Profile
    {
        public TemplateServiceProfiles()
        {
            // source --> target
            //CreateMap<ServiceTemplateShortInfo, ServiceTemplateRead>();
            //CreateMap<ServiceTemplateFullInfo, ServiceTemplateByIdRead>();
            //CreateMap<ServiceTemplateCreate, ServiceTemplateFullInfo>();
        }
    }
}