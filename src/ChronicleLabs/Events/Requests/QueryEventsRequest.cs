using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record QueryEventsRequest
{
    [JsonIgnore]
    public string? Source { get; set; }

    [JsonIgnore]
    public string? Topic { get; set; }

    [JsonIgnore]
    public string? EventType { get; set; }

    [JsonIgnore]
    public string? EntityType { get; set; }

    [JsonIgnore]
    public string? EntityId { get; set; }

    /// <summary>
    /// Page size. Values above 200 are clamped to 200.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque position returned as `next_cursor` by the preceding page.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Relative time window, for example last_7d.
    /// </summary>
    [JsonIgnore]
    public string? Since { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
