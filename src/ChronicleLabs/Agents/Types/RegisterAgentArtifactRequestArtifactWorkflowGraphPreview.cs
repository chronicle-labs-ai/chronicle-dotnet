using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RegisterAgentArtifactRequestArtifactWorkflowGraphPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("edges")]
    public IEnumerable<RegisterAgentArtifactRequestArtifactWorkflowGraphPreviewEdgesItem> Edges { get; set; } =
        new List<RegisterAgentArtifactRequestArtifactWorkflowGraphPreviewEdgesItem>();

    [JsonPropertyName("nodes")]
    public IEnumerable<RegisterAgentArtifactRequestArtifactWorkflowGraphPreviewNodesItem> Nodes { get; set; } =
        new List<RegisterAgentArtifactRequestArtifactWorkflowGraphPreviewNodesItem>();

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
