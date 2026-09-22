using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateTaskSuiteWithTraceRequestTrace : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Accepted for compatibility but never trusted as the authoritative capture. The service re-reads the canonical store by subject.
    /// </summary>
    [JsonPropertyName("eventIds")]
    public IEnumerable<string>? EventIds { get; set; }

    [JsonPropertyName("idempotencyKey")]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// Train / validation / test split assignment.
    /// </summary>
    [JsonPropertyName("split")]
    public CreateTaskSuiteWithTraceRequestTraceSplit? Split { get; set; }

    /// <summary>
    /// Optional task fields. Anything left unset is derived from the captured trace (title from the label, instruction from the first message, expected outcome from the events after the cutoff).
    /// </summary>
    [JsonPropertyName("task")]
    public CreateTaskSuiteWithTraceRequestTraceTask? Task { get; set; }

    [JsonPropertyName("traceId")]
    public required string TraceId { get; set; }

    [JsonPropertyName("traceSynthesized")]
    public bool? TraceSynthesized { get; set; }

    [JsonPropertyName("verifiers")]
    public IEnumerable<CreateTaskSuiteWithTraceRequestTraceVerifiersItem>? Verifiers { get; set; }

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
