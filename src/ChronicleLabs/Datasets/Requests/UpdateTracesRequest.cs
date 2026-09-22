using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record UpdateTracesRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <summary>
    /// Patch to apply to one or more memberships. Nullable annotations preserve the same three states as [`PatchField`]: explicit JSON `null` clears while omission is a no-op.
    /// </summary>
    [JsonPropertyName("patch")]
    public required UpdateTracesRequestPatch Patch { get; set; }

    [JsonPropertyName("traceIds")]
    public IEnumerable<string> TraceIds { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
