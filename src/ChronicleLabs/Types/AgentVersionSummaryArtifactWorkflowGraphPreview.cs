using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentVersionSummaryArtifactWorkflowGraphPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("edges")]
    public IEnumerable<AgentVersionSummaryArtifactWorkflowGraphPreviewEdgesItem> Edges { get; set; } =
        new List<AgentVersionSummaryArtifactWorkflowGraphPreviewEdgesItem>();

    [JsonPropertyName("nodes")]
    public IEnumerable<AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItem> Nodes { get; set; } =
        new List<AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItem>();

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
