using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record BacktestsAvailabilityDatasetSnapshotsValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("clusters")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueClustersItem> Clusters { get; set; } =
        new List<BacktestsAvailabilityDatasetSnapshotsValueClustersItem>();

    [JsonPropertyName("dataset")]
    public required BacktestsAvailabilityDatasetSnapshotsValueDataset Dataset { get; set; }

    [JsonPropertyName("edges")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueEdgesItem> Edges { get; set; } =
        new List<BacktestsAvailabilityDatasetSnapshotsValueEdgesItem>();

    /// <summary>
    /// Optional pre-built event index used by the Timeline tab.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueEventsItem>? Events { get; set; }

    /// <summary>
    /// Task definitions, one per trace. Absent on snapshots built by clients that only render the timeline.
    /// </summary>
    [JsonPropertyName("tasks")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueTasksItem>? Tasks { get; set; }

    [JsonPropertyName("traces")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueTracesItem> Traces { get; set; } =
        new List<BacktestsAvailabilityDatasetSnapshotsValueTracesItem>();

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
