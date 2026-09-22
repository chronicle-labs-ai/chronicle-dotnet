using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListBacktestJobTrialsRequest
{
    [JsonIgnore]
    public required string JobId { get; set; }

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
