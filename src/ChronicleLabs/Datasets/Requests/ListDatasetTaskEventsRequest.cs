using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListDatasetTaskEventsRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string MembershipId { get; set; }

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
