using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record LinkEntityRequest
{
    [JsonPropertyName("from_entity_type")]
    public required string FromEntityType { get; set; }

    [JsonPropertyName("from_entity_id")]
    public required string FromEntityId { get; set; }

    [JsonPropertyName("to_entity_type")]
    public required string ToEntityType { get; set; }

    [JsonPropertyName("to_entity_id")]
    public required string ToEntityId { get; set; }

    [JsonPropertyName("created_by")]
    public string? CreatedBy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
