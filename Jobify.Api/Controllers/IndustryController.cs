using Jobify.Api.Services;
using Jobify.Dto.Industries;
using Microsoft.AspNetCore.Mvc;

namespace Jobify.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = @"Industries")]
[Route("api/industries")]
public class IndustryController(
    IIndustryService industryService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<List<IndustryDto>>> GetIndustries()
    {
        var result = await industryService.GetIndustries();
        return Ok(result);
    }

    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<IndustryDto>> GetIndustry(string name)
    {
        var result = await industryService.GetIndustry(name);
        return StatusCode(result.StatusCode, result.Result);
    }
}