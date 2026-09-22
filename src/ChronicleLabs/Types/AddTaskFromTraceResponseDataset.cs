using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AddTaskFromTraceResponseDataset : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Soft-archive timestamp. Present only when `includeArchived=true` or an archived Dataset is read directly.
    /// </summary>
    [JsonPropertyName("archivedAt")]
    public DateTime? ArchivedAt { get; set; }

    /// <summary>
    /// Display name of the dataset owner / creator.
    /// </summary>
    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Optional total event count across all traces.
    /// </summary>
    [JsonPropertyName("eventCount")]
    public uint? EventCount { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Intended use of a dataset — drives the colored badge on the picker and lets apps route additions to the right backend (eval suite, training set, replay corpus, manual review queue).
    /// </summary>
    [JsonPropertyName("purpose")]
    public AddTaskFromTraceResponseDatasetPurpose? Purpose { get; set; }

    /// <summary>
    /// Free-form pinned tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// Number of traces currently in the dataset.
    /// </summary>
    [JsonPropertyName("traceCount")]
    public required uint TraceCount { get; set; }

    /// <summary>
    /// ISO timestamp of the most recent addition.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

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
