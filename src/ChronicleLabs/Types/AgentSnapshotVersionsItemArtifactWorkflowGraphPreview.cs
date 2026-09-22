using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshotVersionsItemArtifactWorkflowGraphPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("edges")]
    public IEnumerable<AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewEdgesItem> Edges { get; set; } =
        new List<AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewEdgesItem>();

    [JsonPropertyName("nodes")]
    public IEnumerable<AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItem> Nodes { get; set; } =
        new List<AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItem>();

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
