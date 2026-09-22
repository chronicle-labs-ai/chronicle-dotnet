using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateTaskSuiteWithTraceRequest
{
    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("dataset")]
    public required CreateTaskSuiteWithTraceRequestDataset Dataset { get; set; }

    [JsonPropertyName("trace")]
    public required CreateTaskSuiteWithTraceRequestTrace Trace { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
