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
            .AddQueryParameter("count", jobicyApiConfig.CurrentValue.Count)
            .AddQueryParameter("geo", jobicyApiConfig.CurrentValue.Geo)
            .AddQueryParameter("industry", jobicyApiConfig.CurrentValue.Industry)
            .AddHeader("Content-Type", "application/json");

        return await client.ExecuteAsync(request);
    }
}

public interface IJobicyApiClient
{
    Task<RestResponse> GetNewJobOffers();
}