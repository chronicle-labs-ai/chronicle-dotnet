using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateDatasetTaskRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required object Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
