using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshotHashIndexItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Owning agent's display name — lets hash-index results deep-link straight to the agent detail surface.
    /// </summary>
    [JsonPropertyName("agentName")]
    public string? AgentName { get; set; }

    [JsonPropertyName("artifactId")]
    public string? ArtifactId { get; set; }

    /// <summary>
    /// Framework label. Multi-word kebab-case to match the existing TS union (`vercel-ai-sdk`, `openai-agents-python`, etc.).
    /// </summary>
    [JsonPropertyName("framework")]
    public AgentSnapshotHashIndexItemFramework? Framework { get; set; }

    [JsonPropertyName("hash")]
    public required string Hash { get; set; }

    /// <summary>
    /// The 13 hash domains the wrapper tracks. The first eight describe the artifact (config-time); the last five describe a run (observed at call-time).
    /// </summary>
    [JsonPropertyName("kind")]
    public required AgentSnapshotHashIndexItemKind Kind { get; set; }

    [JsonPropertyName("observedAt")]
    public required DateTime ObservedAt { get; set; }

    [JsonPropertyName("path")]
    public required string Path { get; set; }

    /// <summary>
    /// Stringified preview of the value rendered next to the hash.
    /// </summary>
    [JsonPropertyName("preview")]
    public string? Preview { get; set; }

    [JsonPropertyName("runId")]
    public string? RunId { get; set; }

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
