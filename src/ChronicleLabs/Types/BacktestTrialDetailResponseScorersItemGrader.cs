using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record BacktestTrialDetailResponseScorersItemGrader : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Code handler snapshot — required when `kind` is `code`.
    /// </summary>
    [JsonPropertyName("code")]
    public BacktestTrialDetailResponseScorersItemGraderCode? Code { get; set; }

    /// <summary>
    /// Optional human-readable explanation of why this grader was proposed. For rubric graders this doubles as the judge prompt; library scorers inline their prompt here at launch so the recipe stays self-describing.
    /// </summary>
    [JsonPropertyName("evidence")]
    public string? Evidence { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// LLM-judge configuration snapshot (rubric graders). `None` falls back to the default free-score judge behavior.
    /// </summary>
    [JsonPropertyName("judge")]
    public BacktestTrialDetailResponseScorersItemGraderJudge? Judge { get; set; }

    [JsonPropertyName("kind")]
    public required BacktestTrialDetailResponseScorersItemGraderKind Kind { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Scores at or above this value render as passing in results.
    /// </summary>
    [JsonPropertyName("passThreshold")]
    public double? PassThreshold { get; set; }

    /// <summary>
    /// Provenance: the library `Scorer.id` this grader was created from (when `source` is `library`). The prompt is snapshotted into `evidence` at launch, so editing the scorer later never mutates a past run.
    /// </summary>
    [JsonPropertyName("scorerId")]
    public string? ScorerId { get; set; }

    /// <summary>
    /// Grader source — where this grader came from when it was added to the recipe. Determines the chip copy ("proposed" vs "library" vs "custom" vs "dataset").
    /// </summary>
    [JsonPropertyName("source")]
    public required BacktestTrialDetailResponseScorersItemGraderSource Source { get; set; }

    /// <summary>
    /// Grader weight bucket — `low | med | high` matches the segmented control in the GraderBuilder tray.
    /// </summary>
    [JsonPropertyName("weight")]
    public required BacktestTrialDetailResponseScorersItemGraderWeight Weight { get; set; }

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
