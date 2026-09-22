using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record DeleteDatasetTaskRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string MembershipId { get; set; }

    [JsonIgnore]
    public string? Reason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
