using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A connected source and what has been seen from it.
/// </summary>
[Serializable]
public record SourceInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("event_types")]
    public IEnumerable<string> EventTypes { get; set; } = new List<string>();

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
