using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record GetBacktestTrialRequest
{
    [JsonIgnore]
    public required string JobId { get; set; }

    [JsonIgnore]
    public required string TrialId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
