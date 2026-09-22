using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateBacktestJobRequestRecipeAgentsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// CSS color token / hex. Used by `CandidateHueDot`.
    /// </summary>
    [JsonPropertyName("hue")]
    public required string Hue { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Tag rendered next to the label, e.g. "current production".
    /// </summary>
    [JsonPropertyName("notes")]
    public required string Notes { get; set; }

    /// <summary>
    /// Defaults to `candidate`; the Results table treats the first baseline as the reference column.
    /// </summary>
    [JsonPropertyName("role")]
    public CreateBacktestJobRequestRecipeAgentsItemRole? Role { get; set; }

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
