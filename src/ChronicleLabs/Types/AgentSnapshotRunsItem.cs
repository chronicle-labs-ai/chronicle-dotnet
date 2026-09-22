using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshotRunsItem : IJsonOnDeserialized
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
    public AgentSnapshotRunsItemError? Error { get; set; }

    [JsonPropertyName("finishedAt")]
    public DateTime? FinishedAt { get; set; }

    [JsonPropertyName("inputHash")]
    public string? InputHash { get; set; }

    [JsonPropertyName("operation")]
    public required AgentSnapshotRunsItemOperation Operation { get; set; }

    [JsonPropertyName("preparedCall")]
    public AgentSnapshotRunsItemPreparedCall? PreparedCall { get; set; }

    [JsonPropertyName("response")]
    public AgentSnapshotRunsItemResponse? Response { get; set; }

    [JsonPropertyName("runId")]
    public required string RunId { get; set; }

    [JsonPropertyName("schemaVersion")]
    public required string SchemaVersion { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    [JsonPropertyName("status")]
    public required AgentSnapshotRunsItemStatus Status { get; set; }

    [JsonPropertyName("toolCalls")]
    public IEnumerable<AgentSnapshotRunsItemToolCallsItem> ToolCalls { get; set; } =
        new List<AgentSnapshotRunsItemToolCallsItem>();

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
