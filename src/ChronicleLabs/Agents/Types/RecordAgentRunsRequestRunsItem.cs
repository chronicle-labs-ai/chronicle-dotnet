using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RecordAgentRunsRequestRunsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("artifactId")]
    public required string ArtifactId { get; set; }

    [JsonPropertyName("callOptionsHash")]
    public string? CallOptionsHash { get; set; }

    [JsonPropertyName("configHash")]
    public required string ConfigHash { get; set; }

    [JsonPropertyName("durationMs")]
    public uint? DurationMs { get; set; }

    [JsonPropertyName("error")]
    public RecordAgentRunsRequestRunsItemError? Error { get; set; }

    [JsonPropertyName("finishedAt")]
    public DateTime? FinishedAt { get; set; }

    [JsonPropertyName("inputHash")]
    public string? InputHash { get; set; }

    [JsonPropertyName("operation")]
    public required RecordAgentRunsRequestRunsItemOperation Operation { get; set; }

    [JsonPropertyName("preparedCall")]
    public RecordAgentRunsRequestRunsItemPreparedCall? PreparedCall { get; set; }

    [JsonPropertyName("response")]
    public RecordAgentRunsRequestRunsItemResponse? Response { get; set; }

    [JsonPropertyName("runId")]
    public required string RunId { get; set; }

    [JsonPropertyName("schemaVersion")]
    public required string SchemaVersion { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    [JsonPropertyName("status")]
    public required RecordAgentRunsRequestRunsItemStatus Status { get; set; }

    [JsonPropertyName("toolCalls")]
    public IEnumerable<RecordAgentRunsRequestRunsItemToolCallsItem> ToolCalls { get; set; } =
        new List<RecordAgentRunsRequestRunsItemToolCallsItem>();

    [JsonPropertyName("trace")]
    public Dictionary<string, string?>? Trace { get; set; }

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
