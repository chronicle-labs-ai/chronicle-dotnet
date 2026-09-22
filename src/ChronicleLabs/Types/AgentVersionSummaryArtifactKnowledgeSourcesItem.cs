using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentVersionSummaryArtifactKnowledgeSourcesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Optional jump-out link.
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("kind")]
    public required AgentVersionSummaryArtifactKnowledgeSourcesItemKind Kind { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Optional human-readable size hint, e.g. "12.4k docs".
    /// </summary>
    [JsonPropertyName("sizeLabel")]
    public string? SizeLabel { get; set; }

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
