using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshotVersionsItemArtifactToolsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("inputSchemaHash")]
    public string? InputSchemaHash { get; set; }

    /// <summary>
    /// Optional small input-schema preview rendered in the Tools tab.
    /// </summary>
    [JsonPropertyName("inputSchemaPreview")]
    public Dictionary<string, object?>? InputSchemaPreview { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

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
