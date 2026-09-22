using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// LLM-judge configuration snapshot (rubric graders). `None` falls back to the default free-score judge behavior.
/// </summary>
[Serializable]
public record BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemJudge
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Allow the judge to decline non-applicable cases; skipped cases emit no reward key instead of scoring 0.
    /// </summary>
    [JsonPropertyName("allowSkip")]
    public bool? AllowSkip { get; set; }

    /// <summary>
    /// Choice→score mapping. Non-empty forces the judge to pick one choice; the mapped score is the result.
    /// </summary>
    [JsonPropertyName("choiceScores")]
    public IEnumerable<BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemJudgeChoiceScoresItem>? ChoiceScores { get; set; }

    /// <summary>
    /// Judge model override; `None` uses the server default.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Ask the judge to reason step-by-step before answering.
    /// </summary>
    [JsonPropertyName("useCot")]
    public bool? UseCot { get; set; }

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
