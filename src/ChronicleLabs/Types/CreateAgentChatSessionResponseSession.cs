using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A live chat conversation with a registered agent version. Sessions are in-memory (lost on restart); the events, trace, and recorded run are durable.
/// </summary>
[Serializable]
public record CreateAgentChatSessionResponseSession : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agentName")]
    public required string AgentName { get; set; }

    /// <summary>
    /// Resolved registry version the session executes (`current`, else `stable`), pinned at session creation.
    /// </summary>
    [JsonPropertyName("agentVersion")]
    public required string AgentVersion { get; set; }

    [JsonPropertyName("artifactId")]
    public required string ArtifactId { get; set; }

    [JsonPropertyName("messages")]
    public IEnumerable<CreateAgentChatSessionResponseSessionMessagesItem> Messages { get; set; } =
        new List<CreateAgentChatSessionResponseSessionMessagesItem>();

    /// <summary>
    /// Registry run id of the most recently recorded turn. Runs are immutable observations, so each turn records its own run; the shared `traceId` ties them into one conversation.
    /// </summary>
    [JsonPropertyName("runId")]
    public required string RunId { get; set; }

    [JsonPropertyName("sessionId")]
    public required string SessionId { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    /// <summary>
    /// Trace id shared by every event of the conversation. Opens in the timeline and `/v1/trace-tree/:trace_id`.
    /// </summary>
    [JsonPropertyName("traceId")]
    public required string TraceId { get; set; }

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
