using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TrackSignalsRequest
{
    [JsonPropertyName("signals")]
    public IEnumerable<SignalRequest>? Signals { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
