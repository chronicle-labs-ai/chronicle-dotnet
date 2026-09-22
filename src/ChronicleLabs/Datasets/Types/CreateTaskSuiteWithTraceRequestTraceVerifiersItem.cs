using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One verifier bound to a task: a scorer from the tenant library plus the weight and pass threshold it carries for this task. Order is the position in the task's verifier list.
/// </summary>
[Serializable]
public record CreateTaskSuiteWithTraceRequestTraceVerifiersItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("passThreshold")]
    public double? PassThreshold { get; set; }

    [JsonPropertyName("scorerId")]
    public required string ScorerId { get; set; }

    /// <summary>
    /// Grader weight bucket — `low | med | high` matches the segmented control in the GraderBuilder tray.
    /// </summary>
    [JsonPropertyName("weight")]
    public CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight? Weight { get; set; }

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
