using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateBacktestJobRequestRecipeDataScenariosItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accepted")]
    public bool? Accepted { get; set; }

    /// <summary>
    /// Cluster bucket emitted by the data-science layer when looking for missing scenarios in a dataset.
    /// </summary>
    [JsonPropertyName("bucket")]
    public CreateBacktestJobRequestRecipeDataScenariosItemBucket? Bucket { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("clusterLabel")]
    public string? ClusterLabel { get; set; }

    [JsonPropertyName("confidence")]
    public double? Confidence { get; set; }

    [JsonPropertyName("count")]
    public required uint Count { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("kind")]
    public required CreateBacktestJobRequestRecipeDataScenariosItemKind Kind { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

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
