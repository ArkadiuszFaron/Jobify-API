namespace Jobify.Api.Models.Jobicy;

public class JobicyResponse
{
    public string? ApiVersion { get; set; }
    public string? DocumentationUrl { get; set; }
    public string? FriendlyNotice { get; set; }
    public int JobCount { get; set; }
    public string? XRayHash { get; set; }
    public string? ClientKey { get; set; }
    public string? LastUpdate { get; set; }
    public List<JobModel>? Jobs { get; set; }
}