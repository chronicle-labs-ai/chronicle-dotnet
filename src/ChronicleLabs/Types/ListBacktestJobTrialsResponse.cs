using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One stable, ascending page of persisted trial rows and only the rewards attached to those rows.
/// </summary>
[Serializable]
public record ListBacktestJobTrialsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("hasMore")]
    public required bool HasMore { get; set; }

    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("nextOffset")]
    public int? NextOffset { get; set; }

    /// <summary>
    /// Outer key = trial id; inner key = reward name.
    /// </summary>
    [JsonPropertyName("rewards")]
    public Dictionary<string, Dictionary<string, double>> Rewards { get; set; } =
        new Dictionary<string, Dictionary<string, double>>();

    [JsonPropertyName("trials")]
    public IEnumerable<ListBacktestJobTrialsResponseTrialsItem> Trials { get; set; } =
        new List<ListBacktestJobTrialsResponseTrialsItem>();

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
