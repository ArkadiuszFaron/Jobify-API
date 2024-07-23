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

internal sealed class JobService(
    IDbContextFactory<JobifyContext> contextFactory,
    IJobicyApiClient jobicyApiClient,
    IIndustryService industryService,
    ILogger<JobService> logger,
    IMapper mapper) : IJobService
{
    public async Task<ResultStatus<List<JobListDto>>> GetActualJobOffers(int count)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var jobs = context.Jobs
            .Include(_ => _.Company)
            .Include(_ => _.Industry)
            .AsNoTracking()
            .OrderByDescending(_ => _.PubDate)
            .Take(count)
            .Select(_ => mapper.Map<JobListDto>(_))
            .ToList();

        return new ResultStatus<List<JobListDto>>(StatusCodes.Status200OK, jobs);
    }

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

    public async Task<ResultStatus<JobDto>> GetJobOffer(int id)
    {
        var context = await contextFactory.CreateDbContextAsync();

        var job = context.Jobs
            .Include(_ => _.Company)
            .Include(_ => _.Industry)
            .AsEnumerable()
            .Select(mapper.Map<JobDto>)
            .FirstOrDefault(_ => _.Id == id);

        return new ResultStatus<JobDto>(job is null? StatusCodes.Status404NotFound : StatusCodes.Status200OK, job);
    }

    public async Task<ResultStatus> DeleteJobOffer(int id)
    {
        try
        {
            var context = await contextFactory.CreateDbContextAsync();
            
            var job = context.Jobs
                .FirstOrDefault(_ => _.Id == id);

            if (job is null)
            {
                return new ResultStatus(StatusCodes.Status404NotFound);
            }

            context.Jobs.Remove(job);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Cannot delete job offer with id: {id}. Message: {ex.Message}.");
            return new ResultStatus(StatusCodes.Status500InternalServerError, "Cannot delete job offer.");
        }

        return new ResultStatus(StatusCodes.Status200OK);
    }
    
    #region Private methods
    private async Task FillNewJobOffers(List<JobDto> jobs)
    {
        try
        {
            var context = await contextFactory.CreateDbContextAsync();

            foreach (var job in jobs)
            {
                var industryDto = (await industryService.GetIndustry(job.Industry?.Name)).Result;
                var industryEntity = await context.Industries.FindAsync(industryDto?.Id);
                
                var jobEntity = mapper.Map<Job>(job);
                jobEntity.Industry = industryEntity;

                context.Jobs.Add(jobEntity);
                await context.SaveChangesAsync();
            }
            
            logger.LogInformation("Successful filling all new job offers.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Cannot creating new job offer: {ex.Message}");
        }
    }
    #endregion
}

public interface IJobService
{
    Task<ResultStatus<List<JobListDto>>> GetActualJobOffers(int count);
    Task<ResultStatus<List<JobDto>>> GetNewJobOffers();
    Task<ResultStatus<JobDto>> GetJobOffer(int id);
    Task<ResultStatus> DeleteJobOffer(int id);
}