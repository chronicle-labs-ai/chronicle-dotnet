using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RegisterAgentArtifactRequestArtifact : IJsonOnDeserialized
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
    public required RegisterAgentArtifactRequestArtifactFramework Framework { get; set; }

    /// <summary>
    /// Compact preview of the input contract this artifact expects.
    /// </summary>
    [JsonPropertyName("inputContractPreview")]
    public RegisterAgentArtifactRequestArtifactInputContractPreview? InputContractPreview { get; set; }

    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("instructionsHash")]
    public string? InstructionsHash { get; set; }

    [JsonPropertyName("knowledgeSources")]
    public IEnumerable<RegisterAgentArtifactRequestArtifactKnowledgeSourcesItem>? KnowledgeSources { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("model")]
    public required RegisterAgentArtifactRequestArtifactModel Model { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Compact preview of the output contract this artifact emits.
    /// </summary>
    [JsonPropertyName("outputContractPreview")]
    public RegisterAgentArtifactRequestArtifactOutputContractPreview? OutputContractPreview { get; set; }

    [JsonPropertyName("policy")]
    public RegisterAgentArtifactRequestArtifactPolicy? Policy { get; set; }

    [JsonPropertyName("provenance")]
    public required RegisterAgentArtifactRequestArtifactProvenance Provenance { get; set; }

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
    public IEnumerable<RegisterAgentArtifactRequestArtifactToolsItem> Tools { get; set; } =
        new List<RegisterAgentArtifactRequestArtifactToolsItem>();

    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("workflowGraphPreview")]
    public RegisterAgentArtifactRequestArtifactWorkflowGraphPreview? WorkflowGraphPreview { get; set; }

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
