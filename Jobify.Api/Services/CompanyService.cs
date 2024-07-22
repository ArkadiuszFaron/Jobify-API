using AutoMapper;
using Jobify.Api.Models.Common;
using Jobify.Domain.Entities;
using Jobify.Domain.Helpers;
using Jobify.Domain.Repositories;
using Jobify.Dto.Companies;

namespace Jobify.Api.Services;

public class CompanyService(
    IDapperRepository dapperRepository,
    IMapper mapper) : ICompanyService
{
    public async Task<ResultStatus<List<CompanyDto>>> GetCompanies(int count)
    {
        var companies = (await dapperRepository
            .Query<Company>(SqlQueryHelper.GetCompanies))
            .Take(count)
            .Select(mapper.Map<CompanyDto>)
            .ToList();
        
        return new ResultStatus<List<CompanyDto>>(StatusCodes.Status200OK, companies);
    }

    public async Task<ResultStatus<CompanyDto>> GetCompany(int id)
    {
        var company = mapper.Map<CompanyDto>(await dapperRepository
            .QueryFirstOrDefault<Company>(SqlQueryHelper.GetCompanyById, new { id }));
        
        return new ResultStatus<CompanyDto>(company is null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK, company);
    }
}

public interface ICompanyService
{
    Task<ResultStatus<List<CompanyDto>>> GetCompanies(int count);
    Task<ResultStatus<CompanyDto>> GetCompany(int id);
}