using AutoMapper;
using Jobify.Api.Models.Common;
using Jobify.Domain.Entities;
using Jobify.Domain.Helpers;
using Jobify.Domain.Repositories;
using Jobify.Dto.Companies;

namespace Jobify.Api.Services;

internal sealed class CompanyService(
    IDapperRepository dapperRepository,
    ILogger<CompanyService> logger,
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
    
    public async Task<ResultStatus> UpdateCompany(int id, UpdateCompanyDto dto)
    {
        try
        {
            var company = mapper.Map<CompanyDto>(await dapperRepository
                .QueryFirstOrDefault<Company>(SqlQueryHelper.GetCompanyById, new { id }));

            if (company is null)
            {
                return new ResultStatus(StatusCodes.Status404NotFound);
            }

            var result = await dapperRepository.Execute(SqlQueryHelper.UpdateCompany,
                new
                {
                    id = id,
                    name = dto.Name,
                    logo = dto.Logo,
                    modifiedAt = DateTime.UtcNow
                });

            if (result != 1)
            {
                logger.LogError($"Cannot update company with id: {id}. Execution result: {result}.");
                return new ResultStatus(StatusCodes.Status500InternalServerError, "Cannot update company.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Cannot update company with id: {id}. Error: {ex.Message}");
            return new ResultStatus(StatusCodes.Status500InternalServerError, "Cannot update company.");
        }

        return new ResultStatus(StatusCodes.Status200OK);
    }

    public async Task<ResultStatus> DeleteCompany(int id)
    {
        try
        {
            var company = mapper.Map<CompanyDto>(await dapperRepository
                .QueryFirstOrDefault<Company>(SqlQueryHelper.GetCompanyById, new { id }));

            if (company is null)
            {
                return new ResultStatus(StatusCodes.Status404NotFound);
            }

            var result = await dapperRepository.Execute(SqlQueryHelper.DeleteCompany, new { id });
            if (result != 1)
            {
                logger.LogError($"Cannot delete company with id: {id}. Execution result: {result}.");
                return new ResultStatus(StatusCodes.Status500InternalServerError, "Cannot delete company.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Cannot delete company with id: {id}. Message: {ex.Message}.");
            return new ResultStatus(StatusCodes.Status500InternalServerError, "Cannot delete company.");
        }

        return new ResultStatus(StatusCodes.Status200OK);
    }
}

public interface ICompanyService
{
    Task<ResultStatus<List<CompanyDto>>> GetCompanies(int count);
    Task<ResultStatus<CompanyDto>> GetCompany(int id);
    Task<ResultStatus> UpdateCompany(int id, UpdateCompanyDto dto);
    Task<ResultStatus> DeleteCompany(int id);
}