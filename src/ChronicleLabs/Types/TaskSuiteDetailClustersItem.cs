using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TaskSuiteDetailClustersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// CSS color for the cluster (e.g. `"var(--c-event-teal)"`).
    /// </summary>
    [JsonPropertyName("color")]
    public required string Color { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Optional pre-computed centroid hint in normalized [0..1] space.
    /// </summary>
    [JsonPropertyName("similarityCenter")]
    public IEnumerable<double>? SimilarityCenter { get; set; }

    [JsonPropertyName("traceIds")]
    public IEnumerable<string> TraceIds { get; set; } = new List<string>();

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
