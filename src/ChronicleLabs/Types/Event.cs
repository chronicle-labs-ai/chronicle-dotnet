using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A stored event. Immutable once written.
/// </summary>
[Serializable]
public record Event : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Time-ordered identifier, sorts in creation order.
    /// </summary>
    [JsonPropertyName("event_id")]
    public required string EventId { get; set; }

    /// <summary>
    /// Organisation the event belongs to.
    /// </summary>
    [JsonPropertyName("org_id")]
    public required string OrgId { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("topic")]
    public required string Topic { get; set; }

    [JsonPropertyName("event_type")]
    public required string EventType { get; set; }

    /// <summary>
    /// When the event happened at the source.
    /// </summary>
    [JsonPropertyName("event_time")]
    public required DateTime EventTime { get; set; }

    /// <summary>
    /// When Chronicle received it.
    /// </summary>
    [JsonPropertyName("ingestion_time")]
    public required DateTime IngestionTime { get; set; }

    /// <summary>
    /// Source-defined body. Free-form by design.
    /// </summary>
    [JsonPropertyName("payload")]
    public Dictionary<string, object?>? Payload { get; set; }

    [JsonPropertyName("media")]
    public MediaAttachment? Media { get; set; }

    /// <summary>
    /// Entity references supplied with the event at ingest time.
    /// </summary>
    [JsonPropertyName("entity_refs")]
    public IEnumerable<PendingEntityRef>? EntityRefs { get; set; }

    [JsonPropertyName("raw_body")]
    public string? RawBody { get; set; }

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
