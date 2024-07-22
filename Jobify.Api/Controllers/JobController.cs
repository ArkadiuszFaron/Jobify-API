using Jobify.Api.Services;
using Jobify.Dto.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace Jobify.Api.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = @"Jobs")]
[Route("api/jobs")]
public class JobController(
    IJobService jobService) : ControllerBase
{
    [HttpGet("actual")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<List<JobListDto>>> GetActualJobOffers(int count = 1)
    {
        var result = await jobService.GetActualJobOffers(count);
        return Ok(result);
    }
    
    [HttpGet("new")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<List<JobDto>>> GetNewJobOffers()
    {
        var result = await jobService.GetNewJobOffers();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<JobDto>> GetJobOffer(int id)
    {
        var result = await jobService.GetJobOffer(id);
        return StatusCode(result.StatusCode, result.Result);
    }
}