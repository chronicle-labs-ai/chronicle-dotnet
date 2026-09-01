using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListEntitiesRequest
{
    [JsonIgnore]
    public required string EntityType { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
