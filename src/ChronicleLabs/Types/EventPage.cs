using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One page of events, newest first. `next_cursor` is present only when `has_more` is true.
/// </summary>
[Serializable]
public record EventPage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("data")]
    public IEnumerable<EventResult> Data { get; set; } = new List<EventResult>();

    /// <summary>
    /// Whether a further page exists
    /// </summary>
    [JsonPropertyName("has_more")]
    public required bool HasMore { get; set; }

    /// <summary>
    /// Opaque cursor to pass as `cursor` on the next request
    /// </summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

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
