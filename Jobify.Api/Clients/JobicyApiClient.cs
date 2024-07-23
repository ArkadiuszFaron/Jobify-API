using Jobify.Common.Configs;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Jobify.Api.Clients;

public class JobicyApiClient(
    IOptionsMonitor<JobicyApiConfig> jobicyApiConfig) : IJobicyApiClient
{
    public async Task<RestResponse> GetNewJobOffers()
    {
        var client = new RestClient($"{jobicyApiConfig.CurrentValue.Url}");

        var request = new RestRequest()
            .AddQueryParameter("count", jobicyApiConfig.CurrentValue.Count ?? 10)
            .AddHeader("Content-Type", "application/json");

        if (!string.IsNullOrEmpty(jobicyApiConfig.CurrentValue.Geo))
            request.AddQueryParameter("geo", jobicyApiConfig.CurrentValue.Geo);
        
        if (!string.IsNullOrEmpty(jobicyApiConfig.CurrentValue.Industry))
            request.AddQueryParameter("industry", jobicyApiConfig.CurrentValue.Industry);

        return await client.ExecuteAsync(request);
    }
}

public interface IJobicyApiClient
{
    Task<RestResponse> GetNewJobOffers();
}