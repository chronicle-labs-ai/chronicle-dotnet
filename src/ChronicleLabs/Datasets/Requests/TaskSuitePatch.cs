using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record TaskSuitePatch
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Intended use of a dataset — drives the colored badge on the picker and lets apps route additions to the right backend (eval suite, training set, replay corpus, manual review queue).
    /// </summary>
    [JsonPropertyName("purpose")]
    public TaskSuitePatchPurpose? Purpose { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
