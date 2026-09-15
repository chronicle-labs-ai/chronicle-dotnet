using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// An entity type in use and how much of it there is.
/// </summary>
[Serializable]
public record EntityTypeInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entity_type")]
    public required string EntityType { get; set; }

    [JsonPropertyName("entity_count")]
    public required long EntityCount { get; set; }

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
