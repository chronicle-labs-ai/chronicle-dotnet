using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AddTaskFromTraceRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation after an ambiguous network failure. Keys are scoped to the authenticated tenant and operation. Reusing a key with the same payload returns the original successful result; reusing it with a different payload returns 409.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// Accepted for compatibility but never trusted as the authoritative capture. The service re-reads the canonical store by subject.
    /// </summary>
    [JsonPropertyName("eventIds")]
    public IEnumerable<string>? EventIds { get; set; }

    [JsonPropertyName("idempotencyKey")]
    public string? AddTaskFromTraceRequestIdempotencyKey { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// Train / validation / test split assignment.
    /// </summary>
    [JsonPropertyName("split")]
    public AddTaskFromTraceRequestSplit? Split { get; set; }

    /// <summary>
    /// Optional task fields. Anything left unset is derived from the captured trace (title from the label, instruction from the first message, expected outcome from the events after the cutoff).
    /// </summary>
    [JsonPropertyName("task")]
    public AddTaskFromTraceRequestTask? Task { get; set; }

    [JsonPropertyName("traceId")]
    public required string TraceId { get; set; }

    [JsonPropertyName("traceSynthesized")]
    public bool? TraceSynthesized { get; set; }

    [JsonPropertyName("verifiers")]
    public IEnumerable<AddTaskFromTraceRequestVerifiersItem>? Verifiers { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
