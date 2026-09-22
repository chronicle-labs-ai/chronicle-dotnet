using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TaskSuiteSnapshotTracesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("addedAt")]
    public DateTime? AddedAt { get; set; }

    [JsonPropertyName("addedBy")]
    public string? AddedBy { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("durationMs")]
    public required uint DurationMs { get; set; }

    /// <summary>
    /// Pre-computed 2D embedding in normalized `[-1, 1]` space.
    /// </summary>
    [JsonPropertyName("embedding")]
    public IEnumerable<double>? Embedding { get; set; }

    [JsonPropertyName("eventCount")]
    public required uint EventCount { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("primarySource")]
    public required string PrimarySource { get; set; }

    [JsonPropertyName("sources")]
    public IEnumerable<string> Sources { get; set; } = new List<string>();

    /// <summary>
    /// Train / validation / test split assignment.
    /// </summary>
    [JsonPropertyName("split")]
    public TaskSuiteSnapshotTracesItemSplit? Split { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    /// <summary>
    /// Health status of a trace as judged by the dataset owner.
    /// </summary>
    [JsonPropertyName("status")]
    public required TaskSuiteSnapshotTracesItemStatus Status { get; set; }

    [JsonPropertyName("traceId")]
    public required string TraceId { get; set; }

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
