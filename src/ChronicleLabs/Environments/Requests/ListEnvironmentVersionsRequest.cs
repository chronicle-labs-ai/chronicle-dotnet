using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListEnvironmentVersionsRequest
{
    /// <summary>
    /// Environment ID or slug.
    /// </summary>
    [JsonIgnore]
    public required string EnvironmentId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
