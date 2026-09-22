using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record ListDatasetsRequest
{
    [JsonIgnore]
    public bool? IncludeArchived { get; set; }

    [JsonIgnore]
    public string? Query { get; set; }

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
