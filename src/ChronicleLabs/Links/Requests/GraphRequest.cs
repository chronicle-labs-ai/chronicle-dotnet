using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record GraphRequest
{
    [JsonPropertyName("start_event_id")]
    public required string StartEventId { get; set; }

    [JsonPropertyName("direction")]
    public required GraphRequestDirection Direction { get; set; }

    [JsonPropertyName("link_types")]
    public IEnumerable<string>? LinkTypes { get; set; }

    [JsonPropertyName("max_depth")]
    public int? MaxDepth { get; set; }

    [JsonPropertyName("min_confidence")]
    public double? MinConfidence { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
