using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A single event rendered as a mark on the stream timeline. The full shape lives next to dataset shapes because `DatasetSnapshot.events` is the only consumer that ships over the wire today.
/// </summary>
[Serializable]
public record TaskSuiteSnapshotEventsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("actor")]
    public string? Actor { get; set; }

    /// <summary>
    /// Optional explicit color override; falls back to the source color.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Looser, app-defined grouping key (e.g. `conversation_id`).
    /// </summary>
    [JsonPropertyName("correlationKey")]
    public string? CorrelationKey { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// ISO timestamp.
    /// </summary>
    [JsonPropertyName("occurredAt")]
    public required DateTime OccurredAt { get; set; }

    /// <summary>
    /// Direct causal predecessor.
    /// </summary>
    [JsonPropertyName("parentEventId")]
    public string? ParentEventId { get; set; }

    /// <summary>
    /// Raw payload — shown JSON-pretty in the detail panel.
    /// </summary>
    [JsonPropertyName("payload")]
    public object? Payload { get; set; }

    /// <summary>
    /// Source/system the event came from (e.g. `intercom`, `stripe`).
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <summary>
    /// Optional grouping (capture stream id) — currently informational.
    /// </summary>
    [JsonPropertyName("stream")]
    public string? Stream { get; set; }

    /// <summary>
    /// Trace this event belongs to.
    /// </summary>
    [JsonPropertyName("traceId")]
    public string? TraceId { get; set; }

    /// <summary>
    /// Human-friendly label for the trace.
    /// </summary>
    [JsonPropertyName("traceLabel")]
    public string? TraceLabel { get; set; }

    /// <summary>
    /// Event type within the source (e.g. `conversation.created`).
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

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
