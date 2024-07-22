using Newtonsoft.Json;

namespace Jobify.Dto.Jobs;

public class JobListDto
{
    [JsonProperty(Required = Required.Default)]
    public int Id { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Title { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string Type { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string CompanyName { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Geo { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Level { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Excerpt { get; set; }

    [JsonProperty(Required = Required.Always)]
    public DateTime PubDate { get; set; }

    [JsonProperty(Required = Required.Default)]
    public decimal? AnnualSalaryMin { get; set; }

    [JsonProperty(Required = Required.Default)]
    public decimal? AnnualSalaryMax { get; set; }
}