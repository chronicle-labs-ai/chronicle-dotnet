using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// The inferred payload shape for one source and event type.
/// </summary>
[Serializable]
public record SourceSchema : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("org_id")]
    public required string OrgId { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("event_type")]
    public required string EventType { get; set; }

    /// <summary>
    /// Bumped when the inferred shape changes.
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    [JsonPropertyName("field_names")]
    public IEnumerable<string> FieldNames { get; set; } = new List<string>();

    [JsonPropertyName("field_types")]
    public IEnumerable<string> FieldTypes { get; set; } = new List<string>();

    [JsonPropertyName("sample_event")]
    public Dictionary<string, object?>? SampleEvent { get; set; }

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
