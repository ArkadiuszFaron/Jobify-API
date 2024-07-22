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
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<List<JobListDto>>> GetChat()
    {
        var result = await jobService.GetNewJobOffers();
        return Ok(result);
    }
}