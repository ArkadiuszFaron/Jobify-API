using AutoMapper;
using Jobify.Domain.Entities;
using Jobify.Dto.Jobs;

namespace Jobify.Api.Profiles;

public class DtoToDomainProfile : Profile
{
    public DtoToDomainProfile()
    {
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
            .ForMember(d => d.SalaryCurrency, opt => opt.MapFrom(s => s.SalaryCurrency));
    }
}