using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// What a task asks for and how it is judged. Persisted on the membership (mutable working copy) and copied verbatim into every published version item. Verifier bindings live beside it (see `TaskVerifierBinding`).
/// </summary>
[Serializable]
public record BacktestsAvailabilityDatasetSnapshotsValueTasksItemTask : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Runtime knobs a task carries, mirroring the `[agent]`, `[verifier]` and `[environment]` tables of a Harbor `task.toml`. Every field is optional; the server policy fills defaults at launch.
    /// </summary>
    [JsonPropertyName("config")]
    public BacktestsAvailabilityDatasetSnapshotsValueTasksItemTaskConfig? Config { get; set; }

    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("environmentVersionId")]
    public string? EnvironmentVersionId { get; set; }

    /// <summary>
    /// What "done correctly" looks like. Passed to graders as the gold reference. For trace-seeded tasks this defaults to the events that followed the seed cutoff.
    /// </summary>
    [JsonPropertyName("expectedOutcome")]
    public object? ExpectedOutcome { get; set; }

    /// <summary>
    /// The goal, as markdown. Harbor's `instruction.md`.
    /// </summary>
    [JsonPropertyName("instruction")]
    public string? Instruction { get; set; }

    /// <summary>
    /// Id of the last seed event. Events up to and including it are the context the agent sees; later events are the recorded outcome.
    /// </summary>
    [JsonPropertyName("seedCutoffEventId")]
    public string? SeedCutoffEventId { get; set; }

    /// <summary>
    /// Optional oracle: how a correct agent would solve this. Harbor's `solution/solve.sh` body.
    /// </summary>
    [JsonPropertyName("solution")]
    public string? Solution { get; set; }

    /// <summary>
    /// Short human name. Defaults to the trace label for trace-seeded tasks.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

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
