using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record StreamEventsRequest
{
    [JsonIgnore]
    public string? Source { get; set; }

    [JsonIgnore]
    public string? EventType { get; set; }

    [JsonIgnore]
    public string? EntityType { get; set; }

    [JsonIgnore]
    public string? EntityId { get; set; }

    /// <summary>
    /// Opaque id from the last SSE message the client processed.
    /// </summary>
    [JsonIgnore]
    public string? LastEventId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
