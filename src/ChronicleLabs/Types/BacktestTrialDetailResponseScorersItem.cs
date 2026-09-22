using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A scorer as the trial view needs it: the frozen grader snapshot the reward key points at, plus the reward key itself so the UI can join scores to names without reconstructing `grader_&lt;id&gt;`.
///
/// Resolved from the job's pinned Dataset Version items (task verifiers, `source: dataset`) and the recipe's own grader list.
/// </summary>
[Serializable]
public record BacktestTrialDetailResponseScorersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("grader")]
    public required BacktestTrialDetailResponseScorersItemGrader Grader { get; set; }

    /// <summary>
    /// Reward key this scorer's score is stored under (`grader_&lt;id&gt;`).
    /// </summary>
    [JsonPropertyName("rewardKey")]
    public required string RewardKey { get; set; }

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
