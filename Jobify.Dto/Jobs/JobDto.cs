using Jobify.Dto.Companies;
using Jobify.Dto.Industries;
using Newtonsoft.Json;

namespace Jobify.Dto.Jobs;

public class JobDto : IDataTransferObject
{
    [JsonProperty(Required = Required.Default)]
    public int Id { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Title { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Geo { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Level { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Excerpt { get; set; }

    [JsonProperty(Required = Required.Always)]
    public required string Description { get; set; }

    [JsonProperty(Required = Required.Always)]
    public DateTime PubDate { get; set; }

    [JsonProperty(Required = Required.Default)]
    public decimal? AnnualSalaryMin { get; set; }

    [JsonProperty(Required = Required.Default)]
    public decimal? AnnualSalaryMax { get; set; }

    [JsonProperty(Required = Required.Default)]
    public string? SalaryCurrency { get; set; }

    [JsonProperty(Required = Required.Default)]
    public Common.Enums.JobTypes Type { get; set; }

    [JsonProperty(Required = Required.Default)]
    public CompanyDto? Company { get; set; }
    
    [JsonProperty(Required = Required.Default)]
    public IndustryDto? Industry { get; set; }
}