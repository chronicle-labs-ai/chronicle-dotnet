using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateClusterRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("color")]
    public required string Color { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("idempotencyKey")]
    public string? CreateClusterRequestIdempotencyKey { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("similarityCenter")]
    public IEnumerable<double>? SimilarityCenter { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
