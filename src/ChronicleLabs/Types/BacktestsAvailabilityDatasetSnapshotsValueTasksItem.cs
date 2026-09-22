using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One task as frozen in a snapshot: the definition plus its verifiers with scorer content embedded. `trace_id` matches the `TraceSummary` in the same snapshot.
/// </summary>
[Serializable]
public record BacktestsAvailabilityDatasetSnapshotsValueTasksItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("membershipId")]
    public required string MembershipId { get; set; }

    /// <summary>
    /// The canonical event-store subject curated into a Dataset. Providers that cannot form a real trace keep a single event subject rather than inventing a trace identifier. `Task` marks a hand-authored task with no captured subject; its revision holds zero events and its subject id is minted by the service.
    /// </summary>
    [JsonPropertyName("subjectKind")]
    public required BacktestsAvailabilityDatasetSnapshotsValueTasksItemSubjectKind SubjectKind { get; set; }

    /// <summary>
    /// What a task asks for and how it is judged. Persisted on the membership (mutable working copy) and copied verbatim into every published version item. Verifier bindings live beside it (see `TaskVerifierBinding`).
    /// </summary>
    [JsonPropertyName("task")]
    public required BacktestsAvailabilityDatasetSnapshotsValueTasksItemTask Task { get; set; }

    [JsonPropertyName("traceId")]
    public required string TraceId { get; set; }

    [JsonPropertyName("verifiers")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItem> Verifiers { get; set; } =
        new List<BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItem>();

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
