using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CompileEnvironmentRequest
{
    /// <summary>
    /// Environment ID or slug.
    /// </summary>
    [JsonIgnore]
    public required string EnvironmentId { get; set; }

    /// <summary>
    /// Environment-version ID or version label.
    /// </summary>
    [JsonIgnore]
    public required string VersionSelector { get; set; }

    [JsonPropertyName("datasetSnapshotId")]
    public required string DatasetSnapshotId { get; set; }

    [JsonPropertyName("scenarioId")]
    public required string ScenarioId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
