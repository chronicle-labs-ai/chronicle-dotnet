using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RecordAgentRunsRequestRunsItemToolCallsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("argsHash")]
    public string? ArgsHash { get; set; }

    /// <summary>
    /// Optional small preview of the tool args.
    /// </summary>
    [JsonPropertyName("argsPreview")]
    public Dictionary<string, object?>? ArgsPreview { get; set; }

    [JsonPropertyName("callId")]
    public required string CallId { get; set; }

    [JsonPropertyName("durationMs")]
    public uint? DurationMs { get; set; }

    [JsonPropertyName("error")]
    public RecordAgentRunsRequestRunsItemToolCallsItemError? Error { get; set; }

    [JsonPropertyName("finishedAt")]
    public DateTime? FinishedAt { get; set; }

    [JsonPropertyName("resultHash")]
    public string? ResultHash { get; set; }

    [JsonPropertyName("resultPreview")]
    public Dictionary<string, object?>? ResultPreview { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    [JsonPropertyName("status")]
    public required RecordAgentRunsRequestRunsItemToolCallsItemStatus Status { get; set; }

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
