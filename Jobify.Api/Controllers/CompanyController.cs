using Jobify.Api.Services;
using Jobify.Dto.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Jobify.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = @"Companies")]
[Route("api/companies")]
public class CompanyController(
    ICompanyService companyService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies(int count = 1)
    {
        var result = await companyService.GetCompanies(count);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<CompanyDto>> GetCompany(int id)
    {
        var result = await companyService.GetCompany(id);
        return StatusCode(result.StatusCode, result.Result);
    }
}