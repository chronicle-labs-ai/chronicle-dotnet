using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TaskSuiteDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("clusters")]
    public IEnumerable<TaskSuiteDetailClustersItem> Clusters { get; set; } =
        new List<TaskSuiteDetailClustersItem>();

    [JsonPropertyName("dataset")]
    public required TaskSuiteDetailDataset Dataset { get; set; }

    [JsonPropertyName("edges")]
    public IEnumerable<TaskSuiteDetailEdgesItem> Edges { get; set; } =
        new List<TaskSuiteDetailEdgesItem>();

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
