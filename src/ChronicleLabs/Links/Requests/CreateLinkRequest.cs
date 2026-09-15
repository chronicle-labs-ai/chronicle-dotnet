using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateLinkRequest
{
    [JsonPropertyName("source_event_id")]
    public required string SourceEventId { get; set; }

    [JsonPropertyName("target_event_id")]
    public required string TargetEventId { get; set; }

    [JsonPropertyName("link_type")]
    public required string LinkType { get; set; }

    [JsonPropertyName("confidence")]
    public required double Confidence { get; set; }

    [JsonPropertyName("reasoning")]
    public string? Reasoning { get; set; }

    [JsonPropertyName("created_by")]
    public string? CreatedBy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
