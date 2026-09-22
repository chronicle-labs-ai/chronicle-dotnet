using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record SearchAgentHashIndexRequest
{
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Comma-separated hash domains.
    /// </summary>
    [JsonIgnore]
    public string? Domains { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
