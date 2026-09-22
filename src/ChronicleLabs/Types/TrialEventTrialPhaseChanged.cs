using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A trial transitioned phases (queued → running → verifying → done).
/// </summary>
[Serializable]
public record TrialEventTrialPhaseChanged : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("job_id")]
    public required string JobId { get; set; }

    /// <summary>
    /// Phase of execution emitted on the SSE stream as the trial progresses. Distinct from `TrialStatus` — `TrialPhase` is fine-grained progress inside the lifecycle, `TrialStatus` is the persisted summary.
    /// </summary>
    [JsonPropertyName("phase")]
    public required TrialEventTrialPhaseChangedPhase Phase { get; set; }

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
