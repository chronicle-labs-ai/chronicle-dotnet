using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListBacktestJobTrialsRequest
{
    [JsonIgnore]
    public required string JobId { get; set; }

    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque position returned as `next_cursor` by the preceding page.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Deprecated compatibility input. Pass the opaque `cursor` instead.
    /// </summary>
    [JsonIgnore]
    public int? Offset { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
