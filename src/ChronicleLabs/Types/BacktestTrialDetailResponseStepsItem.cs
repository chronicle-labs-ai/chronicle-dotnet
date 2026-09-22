using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Row projection of `"BacktestTrialStep"`.
/// </summary>
[Serializable]
public record BacktestTrialDetailResponseStepsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Who performed a step; one timeline lane per actor.
    /// </summary>
    [JsonPropertyName("actor")]
    public required BacktestTrialDetailResponseStepsItemActor Actor { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// `None` for instantaneous steps (seed events, state changes).
    /// </summary>
    [JsonPropertyName("endedAt")]
    public DateTime? EndedAt { get; set; }

    /// <summary>
    /// Frozen verifier id (or recipe grader id) for `grade` steps.
    /// </summary>
    [JsonPropertyName("graderId")]
    public string? GraderId { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// What a step is. Drives the glyph on the timeline and which detail renderer opens when the span is clicked.
    /// </summary>
    [JsonPropertyName("kind")]
    public required BacktestTrialDetailResponseStepsItemKind Kind { get; set; }

    /// <summary>
    /// Position within the trial; steps are returned ordered by it.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public required uint Ordinal { get; set; }

    /// <summary>
    /// Free-form detail: `request`/`response` for tool calls, `text` for messages, `reasoning` for judge grades, and so on.
    /// </summary>
    [JsonPropertyName("payload")]
    public object? Payload { get; set; }

    /// <summary>
    /// Grader score in `[0, 1]` for `grade` steps.
    /// </summary>
    [JsonPropertyName("score")]
    public double? Score { get; set; }

    [JsonPropertyName("startedAt")]
    public required DateTime StartedAt { get; set; }

    /// <summary>
    /// Outcome colouring for a step. `None` renders neutral.
    /// </summary>
    [JsonPropertyName("status")]
    public BacktestTrialDetailResponseStepsItemStatus? Status { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("trialId")]
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
