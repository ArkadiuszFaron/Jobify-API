using AutoMapper;
using Jobify.Common.Extensions;
using Jobify.Domain.Entities;
using Jobify.Dto.Companies;
using Jobify.Dto.Industries;
using Jobify.Dto.Jobs;

namespace Jobify.Api.Profiles;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.Logo));
        
        CreateMap<Industry, IndustryDto>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code));
        
        CreateMap<Job, JobListDto>()
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.GetEnumDescription()))
            .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Industry.Name))
            .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.Name))
            .ForMember(d => d.Geo, opt => opt.MapFrom(s => s.Geo))
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level))
            .ForMember(d => d.Excerpt, opt => opt.MapFrom(s => s.Excerpt))
            .ForMember(d => d.PubDate, opt => opt.MapFrom(s => s.PubDate))
            .ForMember(d => d.AnnualSalaryMin, opt => opt.MapFrom(s => s.AnnualSalaryMin))
            .ForMember(d => d.AnnualSalaryMax, opt => opt.MapFrom(s => s.AnnualSalaryMax));
        
        CreateMap<Job, JobDto>()
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
            .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Industry))
            .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
            .ForMember(d => d.Geo, opt => opt.MapFrom(s => s.Geo))
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level))
            .ForMember(d => d.Excerpt, opt => opt.MapFrom(s => s.Excerpt))
            .ForMember(d => d.PubDate, opt => opt.MapFrom(s => s.PubDate))
            .ForMember(d => d.AnnualSalaryMin, opt => opt.MapFrom(s => s.AnnualSalaryMin))
            .ForMember(d => d.AnnualSalaryMax, opt => opt.MapFrom(s => s.AnnualSalaryMax));
    }
}