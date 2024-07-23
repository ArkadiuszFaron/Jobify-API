using Newtonsoft.Json;

namespace Jobify.Dto.Industries;

public class IndustryDto : IDataTransferObject
{
    [JsonProperty(Required = Required.Default)]
    public int Id { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string Name { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public required string Code { get; set; }
}