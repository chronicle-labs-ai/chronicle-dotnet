using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// The compact membership projection returned to Dataset and Timeline clients.
/// </summary>
[Serializable]
public record CreateTaskSuiteWithTraceResponseMembership : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("addedAt")]
    public string? AddedAt { get; set; }

    [JsonPropertyName("datasetId")]
    public required string DatasetId { get; set; }

    [JsonPropertyName("datasetName")]
    public required string DatasetName { get; set; }

    [JsonPropertyName("eventCount")]
    public required uint EventCount { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// Intended use of a dataset — drives the colored badge on the picker and lets apps route additions to the right backend (eval suite, training set, replay corpus, manual review queue).
    /// </summary>
    [JsonPropertyName("purpose")]
    public CreateTaskSuiteWithTraceResponseMembershipPurpose? Purpose { get; set; }

    [JsonPropertyName("refreshAvailable")]
    public required bool RefreshAvailable { get; set; }

    [JsonPropertyName("revision")]
    public required uint Revision { get; set; }

    /// <summary>
    /// Train / validation / test split assignment.
    /// </summary>
    [JsonPropertyName("split")]
    public CreateTaskSuiteWithTraceResponseMembershipSplit? Split { get; set; }

    [JsonPropertyName("subjectId")]
    public required string SubjectId { get; set; }

    /// <summary>
    /// The canonical event-store subject curated into a Dataset. Providers that cannot form a real trace keep a single event subject rather than inventing a trace identifier. `Task` marks a hand-authored task with no captured subject; its revision holds zero events and its subject id is minted by the service.
    /// </summary>
    [JsonPropertyName("subjectKind")]
    public required CreateTaskSuiteWithTraceResponseMembershipSubjectKind SubjectKind { get; set; }

    /// <summary>
    /// Compatibility identity consumed by the Timeline picker. For an event membership this is the event id.
    /// </summary>
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
