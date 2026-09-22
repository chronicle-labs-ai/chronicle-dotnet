using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One task in a dataset: the trace summary (its seed, when it has one), the stable membership identity used for lazy event reads and explicit refreshes, and the task definition with its verifier bindings.
/// </summary>
[Serializable]
public record TaskPageItemsItem : IJsonOnDeserialized
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

    [JsonPropertyName("membershipId")]
    public required string MembershipId { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("primarySource")]
    public required string PrimarySource { get; set; }

    [JsonPropertyName("refreshAvailable")]
    public required bool RefreshAvailable { get; set; }

    [JsonPropertyName("revision")]
    public required uint Revision { get; set; }

    [JsonPropertyName("sources")]
    public IEnumerable<string> Sources { get; set; } = new List<string>();

    /// <summary>
    /// Train / validation / test split assignment.
    /// </summary>
    [JsonPropertyName("split")]
    public TaskPageItemsItemSplit? Split { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    /// <summary>
    /// Health status of a trace as judged by the dataset owner.
    /// </summary>
    [JsonPropertyName("status")]
    public required TaskPageItemsItemStatus Status { get; set; }

    [JsonPropertyName("subjectId")]
    public required string SubjectId { get; set; }

    /// <summary>
    /// The canonical event-store subject curated into a Dataset. Providers that cannot form a real trace keep a single event subject rather than inventing a trace identifier. `Task` marks a hand-authored task with no captured subject; its revision holds zero events and its subject id is minted by the service.
    /// </summary>
    [JsonPropertyName("subjectKind")]
    public required TaskPageItemsItemSubjectKind SubjectKind { get; set; }

    /// <summary>
    /// What a task asks for and how it is judged. Persisted on the membership (mutable working copy) and copied verbatim into every published version item. Verifier bindings live beside it (see `TaskVerifierBinding`).
    /// </summary>
    [JsonPropertyName("task")]
    public TaskPageItemsItemTask? Task { get; set; }

    [JsonPropertyName("traceId")]
    public required string TraceId { get; set; }

    [JsonPropertyName("verifiers")]
    public IEnumerable<TaskPageItemsItemVerifiersItem>? Verifiers { get; set; }

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
