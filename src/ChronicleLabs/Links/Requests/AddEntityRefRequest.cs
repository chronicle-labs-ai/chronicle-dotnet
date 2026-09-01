using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AddEntityRefRequest
{
    [JsonPropertyName("event_id")]
    public required string EventId { get; set; }

    [JsonPropertyName("entity_type")]
    public required string EntityType { get; set; }

    [JsonPropertyName("entity_id")]
    public required string EntityId { get; set; }

    [JsonPropertyName("created_by")]
    public string? CreatedBy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
