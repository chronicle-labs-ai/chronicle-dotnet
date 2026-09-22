using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Returned by `GET /api/platform/backtests/availability`. Matches the frontend's `BacktestsAvailability`. Datasets, environments, and agents come from their respective domain crates' types — the IDs in these slices are what the recipe references.
/// </summary>
[Serializable]
public record BacktestsAvailability : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agents")]
    public IEnumerable<BacktestsAvailabilityAgentsItem> Agents { get; set; } =
        new List<BacktestsAvailabilityAgentsItem>();

    [JsonPropertyName("datasetSnapshots")]
    public Dictionary<
        string,
        BacktestsAvailabilityDatasetSnapshotsValue
    > DatasetSnapshots { get; set; } =
        new Dictionary<string, BacktestsAvailabilityDatasetSnapshotsValue>();

    [JsonPropertyName("datasets")]
    public IEnumerable<BacktestsAvailabilityDatasetsItem> Datasets { get; set; } =
        new List<BacktestsAvailabilityDatasetsItem>();

    /// <summary>
    /// Environment row identities + status. Detailed snapshot lives behind `GET /api/platform/environments/:id`.
    /// </summary>
    [JsonPropertyName("environments")]
    public IEnumerable<BacktestsAvailabilityEnvironmentsItem> Environments { get; set; } =
        new List<BacktestsAvailabilityEnvironmentsItem>();

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
