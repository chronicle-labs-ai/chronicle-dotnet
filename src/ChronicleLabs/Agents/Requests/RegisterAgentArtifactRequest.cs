using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RegisterAgentArtifactRequest
{
    [JsonPropertyName("artifact")]
    public required RegisterAgentArtifactRequestArtifact Artifact { get; set; }

    /// <summary>
    /// Mutable, human-authored metadata attached to a logical Agent identity. Artifact configuration remains immutable inside `AgentRegistryVersionRecord`.
    /// </summary>
    [JsonPropertyName("metadata")]
    public RegisterAgentArtifactRequestMetadata? Metadata { get; set; }

    /// <summary>
    /// Defaults to `current`. Registering a new current version atomically demotes the previous current version to stable.
    /// </summary>
    [JsonPropertyName("status")]
    public RegisterAgentArtifactRequestStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
