using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record PublishVersionRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("idempotencyKey")]
    public string? PublishVersionRequestIdempotencyKey { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
