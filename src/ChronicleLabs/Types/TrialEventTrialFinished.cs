using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A trial reached a terminal status.
/// </summary>
[Serializable]
public record TrialEventTrialFinished : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Captured exception info for a failed trial. Mirrors Harbor's `ExceptionInfo` — kind for routing/retry, message for humans.
    /// </summary>
    [JsonPropertyName("exception")]
    public TrialEventTrialFinishedException? Exception { get; set; }

    [JsonPropertyName("job_id")]
    public required string JobId { get; set; }

    /// <summary>
    /// Lifecycle state of a single `BacktestTrial` (one (case × agent) cell).
    /// </summary>
    [JsonPropertyName("status")]
    public required TrialEventTrialFinishedStatus Status { get; set; }

    [JsonPropertyName("trial_id")]
    public required string TrialId { get; set; }

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
