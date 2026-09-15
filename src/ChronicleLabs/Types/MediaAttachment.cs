using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Media attached to an event, stored inline or by reference.
/// </summary>
[Serializable]
public record MediaAttachment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("media_type")]
    public required string MediaType { get; set; }

    /// <summary>
    /// Inline bytes for small media. Absent when stored externally.
    /// </summary>
    [JsonPropertyName("inline_blob")]
    public string? InlineBlob { get; set; }

    /// <summary>
    /// URI for externally stored media. Absent when inline.
    /// </summary>
    [JsonPropertyName("external_ref")]
    public string? ExternalRef { get; set; }

    [JsonPropertyName("size_bytes")]
    public required long SizeBytes { get; set; }

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
