using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record GetTimelineRequest
{
    [JsonIgnore]
    public required string EntityType { get; set; }

    [JsonIgnore]
    public required string EntityId { get; set; }

    /// <summary>
    /// Page size. Values above the maximum are reduced to it, not rejected.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque cursor from a previous response's next_cursor
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Relative time window, for example last_7d.
    /// </summary>
    [JsonIgnore]
    public string? Since { get; set; }

    [JsonIgnore]
    public bool? IncludeLinked { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
