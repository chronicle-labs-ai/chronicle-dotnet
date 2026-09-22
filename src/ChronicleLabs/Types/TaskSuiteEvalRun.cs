using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TaskSuiteEvalRun : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Display label — usually `agent.name@version` or a build hash.
    /// </summary>
    [JsonPropertyName("agentLabel")]
    public required string AgentLabel { get; set; }

    /// <summary>
    /// Tasks that did not pass (see `task_results`).
    /// </summary>
    [JsonPropertyName("failedTraceIds")]
    public IEnumerable<string> FailedTraceIds { get; set; } = new List<string>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// 0–1; null while running.
    /// </summary>
    [JsonPropertyName("passRate")]
    public double? PassRate { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    /// <summary>
    /// Status badge tone for an eval run.
    /// </summary>
    [JsonPropertyName("status")]
    public required TaskSuiteEvalRunStatus Status { get; set; }

    /// <summary>
    /// One entry per task whose trials have all finished.
    /// </summary>
    [JsonPropertyName("taskResults")]
    public IEnumerable<TaskSuiteEvalRunTaskResultsItem>? TaskResults { get; set; }

    [JsonPropertyName("totalCount")]
    public required uint TotalCount { get; set; }

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
