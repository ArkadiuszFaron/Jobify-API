using AutoMapper;
using Jobify.Api.Models.Common;
using Jobify.Domain.Entities;
using Jobify.Domain.Helpers;
using Jobify.Domain.Repositories;
using Jobify.Dto.Industries;

namespace Jobify.Api.Services;

internal sealed class IndustryService(
    IDapperRepository dapperRepository,
    IMapper mapper) : IIndustryService
{
    public async Task<ResultStatus<List<IndustryDto>>> GetIndustries()
    {
        var industries = (await dapperRepository
            .Query<Industry>(SqlQueryHelper.GetIndustries))
            .AsEnumerable()
            .Select(mapper.Map<IndustryDto>)
            .ToList();
        
        return new ResultStatus<List<IndustryDto>>(StatusCodes.Status200OK, industries);
    }

    public async Task<ResultStatus<IndustryDto>> GetIndustry(string name)
    {
        var industry = mapper.Map<IndustryDto>(await dapperRepository
            .QueryFirstOrDefault<Industry>(SqlQueryHelper.GetIndustryByName, new { name }));
        
        return new ResultStatus<IndustryDto>(industry is null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK, industry);
    }
}

public interface IIndustryService
{
    Task<ResultStatus<List<IndustryDto>>> GetIndustries();
    Task<ResultStatus<IndustryDto>> GetIndustry(string code);
}