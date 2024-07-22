using AutoMapper;
using Jobify.Api.Clients;
using Jobify.Api.Models.Common;
using Jobify.Api.Models.Jobicy;
using Jobify.Domain.Contexts;
using Jobify.Domain.Entities;
using Jobify.Dto.Jobs;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Jobify.Api.Services;

public sealed class JobService(
    IDbContextFactory<JobifyContext> contextFactory,
    IJobicyApiClient jobicyApiClient,
    ILogger<JobService> logger,
    IMapper mapper) : IJobService
{
    public async Task<ResultStatus<List<JobDto>>> GetNewJobOffers()
    {
        var response = await jobicyApiClient.GetNewJobOffers();
        if (!response.IsSuccessful)
        {
            return new ResultStatus<List<JobDto>>(StatusCodes.Status200OK, new List<JobDto>());
        }

        var newJobs = JsonConvert.DeserializeObject<JobicyResponse>(response.Content)?.Jobs?
            .Select(mapper.Map<JobDto>)
            .ToList();

        await FillNewJobOffers(newJobs);

        return new ResultStatus<List<JobDto>>(StatusCodes.Status200OK, newJobs);
    }

    private async Task FillNewJobOffers(List<JobDto> jobs)
    {
        try
        {
            var context = await contextFactory.CreateDbContextAsync();

            foreach (var job in jobs)
            {
                context.Jobs.Add(mapper.Map<Job>(job));
                await context.SaveChangesAsync();
            }
            
            logger.LogInformation("Successful filling all new job offers.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot creating new job offer: {ex.Message}");
        }
    }
}

public interface IJobService
{
    Task<ResultStatus<List<JobDto>>> GetNewJobOffers();
}