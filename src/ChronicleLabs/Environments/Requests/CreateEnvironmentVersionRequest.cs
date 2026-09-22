using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateEnvironmentVersionRequest
{
    /// <summary>
    /// Environment ID or slug.
    /// </summary>
    [JsonIgnore]
    public required string EnvironmentId { get; set; }

    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("spec")]
    public EnvironmentSpec? Spec { get; set; }

    [JsonPropertyName("status")]
    public EnvironmentVersionStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
