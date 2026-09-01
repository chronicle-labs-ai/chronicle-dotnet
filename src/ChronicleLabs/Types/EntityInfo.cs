using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A single entity and its event volume.
/// </summary>
[Serializable]
public record EntityInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entity_type")]
    public required string EntityType { get; set; }

    [JsonPropertyName("entity_id")]
    public required string EntityId { get; set; }

    [JsonPropertyName("event_count")]
    public required long EventCount { get; set; }

    [JsonPropertyName("first_seen")]
    public DateTime? FirstSeen { get; set; }

    [JsonPropertyName("last_seen")]
    public DateTime? LastSeen { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
