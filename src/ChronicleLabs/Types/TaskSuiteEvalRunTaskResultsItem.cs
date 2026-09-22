using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// How one task fared in an eval run, aggregated over its trials.
///
/// A task passes when every trial reached a terminal success and each verifier that declares a `passThreshold` scored at or above it.
/// </summary>
[Serializable]
public record TaskSuiteEvalRunTaskResultsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Verifiers whose reward fell below their pass threshold (or was missing) in at least one trial.
    /// </summary>
    [JsonPropertyName("failedVerifierIds")]
    public IEnumerable<string>? FailedVerifierIds { get; set; }

    [JsonPropertyName("passed")]
    public required bool Passed { get; set; }

    /// <summary>
    /// Mean of the top-level rewards across the task's trials; null when no trial recorded a reward.
    /// </summary>
    [JsonPropertyName("score")]
    public double? Score { get; set; }

    /// <summary>
    /// The task id (the membership subject id, which is also the case id).
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
