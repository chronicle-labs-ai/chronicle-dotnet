using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshotVersionsItemArtifact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("artifactId")]
    public required string ArtifactId { get; set; }

    [JsonPropertyName("configHash")]
    public required string ConfigHash { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Framework label. Multi-word kebab-case to match the existing TS union (`vercel-ai-sdk`, `openai-agents-python`, etc.).
    /// </summary>
    [JsonPropertyName("framework")]
    public required AgentSnapshotVersionsItemArtifactFramework Framework { get; set; }

    /// <summary>
    /// Compact preview of the input contract this artifact expects.
    /// </summary>
    [JsonPropertyName("inputContractPreview")]
    public AgentSnapshotVersionsItemArtifactInputContractPreview? InputContractPreview { get; set; }

    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("instructionsHash")]
    public string? InstructionsHash { get; set; }

    [JsonPropertyName("knowledgeSources")]
    public IEnumerable<AgentSnapshotVersionsItemArtifactKnowledgeSourcesItem>? KnowledgeSources { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("model")]
    public required AgentSnapshotVersionsItemArtifactModel Model { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Compact preview of the output contract this artifact emits.
    /// </summary>
    [JsonPropertyName("outputContractPreview")]
    public AgentSnapshotVersionsItemArtifactOutputContractPreview? OutputContractPreview { get; set; }

    [JsonPropertyName("policy")]
    public AgentSnapshotVersionsItemArtifactPolicy? Policy { get; set; }

    [JsonPropertyName("provenance")]
    public required AgentSnapshotVersionsItemArtifactProvenance Provenance { get; set; }

    [JsonPropertyName("providerOptions")]
    public Dictionary<string, object?>? ProviderOptions { get; set; }

    [JsonPropertyName("providerOptionsHash")]
    public string? ProviderOptionsHash { get; set; }

    /// <summary>
    /// Schema marker — frontend code matches against the literal string `"agent-artifact-v1"` so newer payloads can co-exist when we evolve the shape.
    /// </summary>
    [JsonPropertyName("schemaVersion")]
    public required string SchemaVersion { get; set; }

    [JsonPropertyName("tools")]
    public IEnumerable<AgentSnapshotVersionsItemArtifactToolsItem> Tools { get; set; } =
        new List<AgentSnapshotVersionsItemArtifactToolsItem>();

    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("workflowGraphPreview")]
    public AgentSnapshotVersionsItemArtifactWorkflowGraphPreview? WorkflowGraphPreview { get; set; }

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
