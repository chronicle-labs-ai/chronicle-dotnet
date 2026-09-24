using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateBacktestJobRequest
{
    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation after an ambiguous network failure. Keys are scoped to the authenticated tenant and operation. Reusing a key with the same payload returns the original successful result; reusing it with a different payload returns 409.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("cases")]
    public IEnumerable<CreateBacktestJobRequestCasesItem>? Cases { get; set; }

    [JsonPropertyName("evaluatorProfileId")]
    public string? EvaluatorProfileId { get; set; }

    [JsonPropertyName("nConcurrent")]
    public uint? NConcurrent { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("recipe")]
    public required CreateBacktestJobRequestRecipe Recipe { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
