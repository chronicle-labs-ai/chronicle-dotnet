using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One declared twin: which model to run and which captured hosts feed its seed (empty means the model's default, e.g. `slack.com`).
/// </summary>
[Serializable]
public record EnvironmentVersionRecordSpecTwinsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("authorities")]
    public IEnumerable<string>? Authorities { get; set; }

    /// <summary>
    /// Image override; defaults to the platform's per-service template.
    /// </summary>
    [JsonPropertyName("image")]
    public string? Image { get; set; }

    /// <summary>
    /// Twin model name, e.g. `slack`.
    /// </summary>
    [JsonPropertyName("service")]
    public required string Service { get; set; }

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
