using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshotVersionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("artifact")]
    public required AgentSnapshotVersionsItemArtifact Artifact { get; set; }

    [JsonPropertyName("lastRunAt")]
    public DateTime? LastRunAt { get; set; }

    [JsonPropertyName("meanDurationMs")]
    public uint? MeanDurationMs { get; set; }

    [JsonPropertyName("p95DurationMs")]
    public uint? P95DurationMs { get; set; }

    [JsonPropertyName("resolvedModelIds")]
    public IEnumerable<string> ResolvedModelIds { get; set; } = new List<string>();

    [JsonPropertyName("runCount")]
    public required uint RunCount { get; set; }

    [JsonPropertyName("status")]
    public required AgentSnapshotVersionsItemStatus Status { get; set; }

    /// <summary>
    /// Successful runs / total runs (0..1).
    /// </summary>
    [JsonPropertyName("successRate")]
    public required double SuccessRate { get; set; }

    [JsonPropertyName("totalTokens")]
    public uint? TotalTokens { get; set; }

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
