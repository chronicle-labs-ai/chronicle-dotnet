using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListBacktestJobsRequest
{
    [JsonIgnore]
    public string? Mode { get; set; }

    [JsonIgnore]
    public string? Status { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
