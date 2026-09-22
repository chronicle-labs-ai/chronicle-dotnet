using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record GetDatasetSnapshotRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
