using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record SendAgentChatMessageResponseSessionMessagesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Present when the turn failed — the transcript keeps the user message and surfaces the failure instead of fabricating a reply.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Canonical event ids this message ingested into the event store.
    /// </summary>
    [JsonPropertyName("eventIds")]
    public IEnumerable<string>? EventIds { get; set; }

    [JsonPropertyName("messageId")]
    public required string MessageId { get; set; }

    [JsonPropertyName("occurredAt")]
    public required DateTime OccurredAt { get; set; }

    [JsonPropertyName("role")]
    public required SendAgentChatMessageResponseSessionMessagesItemRole Role { get; set; }

    /// <summary>
    /// Tool calls made while producing this message. Empty for user messages and failed turns.
    /// </summary>
    [JsonPropertyName("steps")]
    public IEnumerable<SendAgentChatMessageResponseSessionMessagesItemStepsItem>? Steps { get; set; }

    [JsonPropertyName("text")]
    public required string Text { get; set; }

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
