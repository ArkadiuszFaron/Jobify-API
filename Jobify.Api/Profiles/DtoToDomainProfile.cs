using AutoMapper;
using Jobify.Domain.Entities;
using Jobify.Dto.Companies;
using Jobify.Dto.Industries;
using Jobify.Dto.Jobs;

namespace Jobify.Api.Profiles;

public class DtoToDomainProfile : Profile
{
    public DtoToDomainProfile()
    {
        CreateMap<CompanyDto, Company>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Logo, opt => opt.MapFrom(s => s.Logo));
        
        CreateMap<IndustryDto, Industry>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code));
        
        CreateMap<JobDto, Job>()
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
            .ForMember(d => d.Geo, opt => opt.MapFrom(s => s.Geo))
            .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level))
            .ForMember(d => d.Excerpt, opt => opt.MapFrom(s => s.Excerpt))
            .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
            .ForMember(d => d.PubDate, opt => opt.MapFrom(s => s.PubDate))
            .ForMember(d => d.AnnualSalaryMin, opt => opt.MapFrom(s => s.AnnualSalaryMin))
            .ForMember(d => d.AnnualSalaryMax, opt => opt.MapFrom(s => s.AnnualSalaryMax))
            .ForMember(d => d.SalaryCurrency, opt => opt.MapFrom(s => s.SalaryCurrency))
            .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
            .ForMember(d => d.Industry, opt => opt.MapFrom(s => s.Industry));
    }
}