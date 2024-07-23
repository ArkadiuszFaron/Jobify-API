using AutoMapper;
using Jobify.Api.Models.Jobicy;
using Jobify.Dto.Companies;
using Jobify.Dto.Industries;
using Jobify.Dto.Jobs;

namespace Jobify.Api.Profiles;

public class ModelToDtoProfile : Profile
{
    public ModelToDtoProfile()
    {
        CreateMap<CompanyModel, CompanyDto>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.Logo));
        
        CreateMap<IndustryModel, IndustryDto>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        
        CreateMap<JobModel, JobDto>()
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.JobTitle))
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
            .ForMember(d => d.Geo, opt => opt.MapFrom(s => s.JobGeo))
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.JobLevel))
            .ForMember(d => d.Excerpt, opt => opt.MapFrom(s => s.JobExcerpt))
            .ForMember(d => d.Description, opt => opt.MapFrom(s => s.JobDescription))
            .ForMember(d => d.PubDate, opt => opt.MapFrom(s => s.PubDate))
            .ForMember(d => d.AnnualSalaryMin, opt => opt.MapFrom(s => s.AnnualSalaryMin))
            .ForMember(d => d.AnnualSalaryMax, opt => opt.MapFrom(s => s.AnnualSalaryMax))
            .ForMember(d => d.SalaryCurrency, opt => opt.MapFrom(s => s.SalaryCurrency));
    }
}