using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Row projection of `"BacktestTrial"`.
/// </summary>
[Serializable]
public record BacktestTrialDetailResponseTrial : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agentId")]
    public required string AgentId { get; set; }

    [JsonPropertyName("agentLabel")]
    public required string AgentLabel { get; set; }

    [JsonPropertyName("attempt")]
    public required uint Attempt { get; set; }

    [JsonPropertyName("caseCluster")]
    public string? CaseCluster { get; set; }

    [JsonPropertyName("caseId")]
    public required string CaseId { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("durationMs")]
    public uint? DurationMs { get; set; }

    /// <summary>
    /// Captured exception info for a failed trial. Mirrors Harbor's `ExceptionInfo` — kind for routing/retry, message for humans.
    /// </summary>
    [JsonPropertyName("exception")]
    public BacktestTrialDetailResponseTrialException? Exception { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The case instruction this trial executed — persisted at launch so result surfaces can show the real prompt instead of reconstructing (or inventing) one client-side.
    /// </summary>
    [JsonPropertyName("instruction")]
    public string? Instruction { get; set; }

    [JsonPropertyName("isBaseline")]
    public required bool IsBaseline { get; set; }

    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    [JsonPropertyName("sandboxId")]
    public string? SandboxId { get; set; }

    /// <summary>
    /// Lifecycle state of a single `BacktestTrial` (one (case × agent) cell).
    /// </summary>
    [JsonPropertyName("status")]
    public required BacktestTrialDetailResponseTrialStatus Status { get; set; }

    [JsonPropertyName("tenantId")]
    public required string TenantId { get; set; }

    /// <summary>
    /// Per-phase timing bookkeeping. Each pair is `(started_at, finished_at)`; `None` until that phase starts/ends.
    /// </summary>
    [JsonPropertyName("timings")]
    public required BacktestTrialDetailResponseTrialTimings Timings { get; set; }

    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

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
