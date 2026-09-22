using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Returned by `GET /api/platform/backtests/jobs/:id/trials/:trialId`. Everything the trial detail view renders in one round trip.
/// </summary>
[Serializable]
public record BacktestTrialDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("artifacts")]
    public IEnumerable<BacktestTrialDetailResponseArtifactsItem> Artifacts { get; set; } =
        new List<BacktestTrialDetailResponseArtifactsItem>();

    /// <summary>
    /// Reward name → score for this trial.
    /// </summary>
    [JsonPropertyName("rewards")]
    public Dictionary<string, double> Rewards { get; set; } = new Dictionary<string, double>();

    /// <summary>
    /// Scorers bound to this trial's task (frozen verifiers first, then recipe-level graders), in binding order.
    /// </summary>
    [JsonPropertyName("scorers")]
    public IEnumerable<BacktestTrialDetailResponseScorersItem> Scorers { get; set; } =
        new List<BacktestTrialDetailResponseScorersItem>();

    /// <summary>
    /// Timeline steps ordered by ordinal.
    /// </summary>
    [JsonPropertyName("steps")]
    public IEnumerable<BacktestTrialDetailResponseStepsItem> Steps { get; set; } =
        new List<BacktestTrialDetailResponseStepsItem>();

    /// <summary>
    /// Row projection of `"BacktestTrial"`.
    /// </summary>
    [JsonPropertyName("trial")]
    public required BacktestTrialDetailResponseTrial Trial { get; set; }

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
