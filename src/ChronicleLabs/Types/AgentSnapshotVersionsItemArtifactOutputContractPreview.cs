using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Compact preview of the output contract this artifact emits.
/// </summary>
[Serializable]
public record AgentSnapshotVersionsItemArtifactOutputContractPreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Representative example payload.
    /// </summary>
    [JsonPropertyName("example")]
    public object? Example { get; set; }

    /// <summary>
    /// One-line shape summary.
    /// </summary>
    [JsonPropertyName("schemaSummary")]
    public string? SchemaSummary { get; set; }

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
