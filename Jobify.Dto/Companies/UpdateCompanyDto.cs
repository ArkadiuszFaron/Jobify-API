using Newtonsoft.Json;

namespace Jobify.Dto.Companies;

public class UpdateCompanyDto : IDataTransferObject
{
    [JsonProperty(Required = Required.Always)]
    public required string Name { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string Logo { get; set; }
}