using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record SignalRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("event_id")]
    public required string EventId { get; set; }

    [JsonPropertyName("signal_name")]
    public required string SignalName { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("properties")]
    public object? Properties { get; set; }

    [JsonPropertyName("attachment_id")]
    public string? AttachmentId { get; set; }

    [JsonPropertyName("signal_type")]
    public string? SignalType { get; set; }

    [JsonPropertyName("sentiment")]
    public string? Sentiment { get; set; }

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
