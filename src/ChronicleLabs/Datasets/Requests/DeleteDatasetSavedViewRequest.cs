using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record DeleteDatasetSavedViewRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string ViewId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
