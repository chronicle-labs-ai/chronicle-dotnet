using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TaskSuiteSnapshot : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("clusters")]
    public IEnumerable<TaskSuiteSnapshotClustersItem> Clusters { get; set; } =
        new List<TaskSuiteSnapshotClustersItem>();

    [JsonPropertyName("dataset")]
    public required TaskSuiteSnapshotDataset Dataset { get; set; }

    [JsonPropertyName("edges")]
    public IEnumerable<TaskSuiteSnapshotEdgesItem> Edges { get; set; } =
        new List<TaskSuiteSnapshotEdgesItem>();

    /// <summary>
    /// Optional pre-built event index used by the Timeline tab.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<TaskSuiteSnapshotEventsItem>? Events { get; set; }

    /// <summary>
    /// Task definitions, one per trace. Absent on snapshots built by clients that only render the timeline.
    /// </summary>
    [JsonPropertyName("tasks")]
    public IEnumerable<TaskSuiteSnapshotTasksItem>? Tasks { get; set; }

    [JsonPropertyName("traces")]
    public IEnumerable<TaskSuiteSnapshotTracesItem> Traces { get; set; } =
        new List<TaskSuiteSnapshotTracesItem>();

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
