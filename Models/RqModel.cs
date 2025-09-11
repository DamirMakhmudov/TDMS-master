using Newtonsoft.Json;

namespace TdmsExtension.iCommands.Models;

public class RqModel
{
    [JsonProperty("guid")]
    public string? GUID { set; get; }

    [JsonProperty("name")]
    public string? JName { set; get; }

    [JsonProperty("user")]
    public string? JUser { set; get; }
}