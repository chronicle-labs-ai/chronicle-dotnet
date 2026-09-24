using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateSavedViewRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation after an ambiguous network failure. Keys are scoped to the authenticated tenant and operation. Reusing a key with the same payload returns the original successful result; reusing it with a different payload returns 409.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("idempotencyKey")]
    public string? CreateSavedViewRequestIdempotencyKey { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("schemaVersion")]
    public uint? SchemaVersion { get; set; }

    [JsonPropertyName("scope")]
    public required CreateSavedViewRequestScope Scope { get; set; }

    [JsonPropertyName("shortcut")]
    public string? Shortcut { get; set; }

    [JsonPropertyName("state")]
    public required CreateSavedViewRequestState State { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
