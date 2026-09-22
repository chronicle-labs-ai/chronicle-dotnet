using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One tool invocation the agent made while producing a chat turn. Mirrors what the executor reports from the agent's step telemetry; each step is also ingested as timeline events under the session trace (an `agent`/`tool.call` event plus a `source`/`eventType` result event).
/// </summary>
[Serializable]
public record SendAgentChatMessageResponseSessionMessagesItemStepsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("argsPreview")]
    public Dictionary<string, object?>? ArgsPreview { get; set; }

    /// <summary>
    /// Timeline event type of the tool result (e.g. `hotel-offers.search`).
    /// </summary>
    [JsonPropertyName("eventType")]
    public required string EventType { get; set; }

    [JsonPropertyName("resultPreview")]
    public Dictionary<string, object?>? ResultPreview { get; set; }

    /// <summary>
    /// Timeline source the tool call resolved against (e.g. `giata-sim`).
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("stepId")]
    public required string StepId { get; set; }

    /// <summary>
    /// Human-readable one-liner for the transcript and the timeline row.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    [JsonPropertyName("toolName")]
    public required string ToolName { get; set; }

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
