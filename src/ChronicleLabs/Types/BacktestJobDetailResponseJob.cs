using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Row projection of `"BacktestJob"`.
/// </summary>
[Serializable]
public record BacktestJobDetailResponseJob : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("completedTrials")]
    public required uint CompletedTrials { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Mutable Dataset selected when the job was launched.
    /// </summary>
    [JsonPropertyName("datasetId")]
    public string? DatasetId { get; set; }

    /// <summary>
    /// Immutable Dataset Version used to compile this job's cases. Once set, later working-copy edits cannot alter the run inputs.
    /// </summary>
    [JsonPropertyName("datasetVersionId")]
    public string? DatasetVersionId { get; set; }

    [JsonPropertyName("exceptionKind")]
    public string? ExceptionKind { get; set; }

    [JsonPropertyName("failedTrials")]
    public required uint FailedTrials { get; set; }

    [JsonPropertyName("finishedAt")]
    public DateTime? FinishedAt { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("mode")]
    public required BacktestJobDetailResponseJobMode Mode { get; set; }

    [JsonPropertyName("nConcurrent")]
    public required uint NConcurrent { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("recipe")]
    public required object Recipe { get; set; }

    /// <summary>
    /// Retry policy applied to transient trial failures (network errors, sandbox-create timeouts). Mirrors Harbor's `RetryConfig`. Pass `null` on the wire (`None` here) to fall back to defaults.
    /// </summary>
    [JsonPropertyName("retryConfig")]
    public BacktestJobDetailResponseJobRetryConfig? RetryConfig { get; set; }

    /// <summary>
    /// Sandbox driver selected by trusted server policy at submit time. Echoed onto the `BacktestJob.sandboxDriver` column so persisted jobs record which implementation backed the `Sandbox` trait.
    /// </summary>
    [JsonPropertyName("sandboxDriver")]
    public required BacktestJobDetailResponseJobSandboxDriver SandboxDriver { get; set; }

    [JsonPropertyName("scheduledFor")]
    public DateTime? ScheduledFor { get; set; }

    [JsonPropertyName("startedAt")]
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// Lifecycle state of an entire `BacktestJob`. Maps 1:1 onto the `status` column in `migrations/013_create_backtest_runtime.sql`.
    /// </summary>
    [JsonPropertyName("status")]
    public required BacktestJobDetailResponseJobStatus Status { get; set; }

    [JsonPropertyName("tenantId")]
    public required string TenantId { get; set; }

    [JsonPropertyName("totalTrials")]
    public uint? TotalTrials { get; set; }

    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    [JsonPropertyName("verdict")]
    public string? Verdict { get; set; }

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
