using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One judge choice mapped to a numeric score, e.g. `A → 1.0`, `B → 0.5`, `C → 0.0`. When a judge scorer declares choices, the model must pick exactly one and the mapped score is the result.
/// </summary>
[Serializable]
public record TaskSuiteSnapshotTasksItemVerifiersItemJudgeChoiceScoresItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("score")]
    public required double Score { get; set; }

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
