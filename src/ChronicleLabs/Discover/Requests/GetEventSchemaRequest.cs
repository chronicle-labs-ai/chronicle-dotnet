using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record GetEventSchemaRequest
{
    [JsonIgnore]
    public required string Source { get; set; }

    [JsonIgnore]
    public required string EventType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
