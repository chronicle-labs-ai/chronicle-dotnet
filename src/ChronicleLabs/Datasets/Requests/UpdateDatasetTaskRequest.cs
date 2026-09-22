using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record UpdateDatasetTaskRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string MembershipId { get; set; }

    [JsonIgnore]
    public required object Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
