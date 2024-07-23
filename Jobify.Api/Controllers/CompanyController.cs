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
    
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult> UpdateCompany(int id, [FromBody] UpdateCompanyDto? dto)
    {
        if (id < 1 || dto == null)
        {
            return BadRequest();
        }

        var result = await companyService.UpdateCompany(id, dto);

        return result.StatusCode != StatusCodes.Status200OK
            ? StatusCode(result.StatusCode, result.Message)
            : Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<CompanyDto>> DeleteCompany(int id)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        
        var result = await companyService.DeleteCompany(id);

        return result.StatusCode != StatusCodes.Status200OK
            ? StatusCode(result.StatusCode, result.Message)
            : Ok();
    }
}