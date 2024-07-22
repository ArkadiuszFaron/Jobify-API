using Newtonsoft.Json;

namespace Jobify.Dto.Companies;

public class CompanyDto
{
    [JsonProperty(Required = Required.Default)]
    public int Id { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string Name { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string Logo { get; set; }
}