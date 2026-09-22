using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record DatasetSavedViewPatch
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string ViewId { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("scope")]
    public DatasetSavedViewPatchScope? Scope { get; set; }

    [JsonPropertyName("shortcut")]
    public string? Shortcut { get; set; }

    [JsonPropertyName("state")]
    public DatasetSavedViewPatchState? State { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
