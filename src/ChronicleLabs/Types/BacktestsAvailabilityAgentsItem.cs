using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record BacktestsAvailabilityAgentsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("capabilityTags")]
    public IEnumerable<string>? CapabilityTags { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    /// <summary>
    /// Framework label. Multi-word kebab-case to match the existing TS union (`vercel-ai-sdk`, `openai-agents-python`, etc.).
    /// </summary>
    [JsonPropertyName("framework")]
    public required BacktestsAvailabilityAgentsItemFramework Framework { get; set; }

    /// <summary>
    /// Last drift event, if any.
    /// </summary>
    [JsonPropertyName("lastDriftAt")]
    public DateTime? LastDriftAt { get; set; }

    [JsonPropertyName("lastRunAt")]
    public DateTime? LastRunAt { get; set; }

    [JsonPropertyName("latestVersion")]
    public required string LatestVersion { get; set; }

    [JsonPropertyName("model")]
    public required BacktestsAvailabilityAgentsItemModel Model { get; set; }

    [JsonPropertyName("modelLabel")]
    public required string ModelLabel { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("personaSummary")]
    public string? PersonaSummary { get; set; }

    [JsonPropertyName("playgroundUrl")]
    public string? PlaygroundUrl { get; set; }

    [JsonPropertyName("purpose")]
    public string? Purpose { get; set; }

    [JsonPropertyName("runbookUrl")]
    public string? RunbookUrl { get; set; }

    [JsonPropertyName("successRate")]
    public required double SuccessRate { get; set; }

    [JsonPropertyName("totalRuns")]
    public required uint TotalRuns { get; set; }

    [JsonPropertyName("versionCount")]
    public required uint VersionCount { get; set; }

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
