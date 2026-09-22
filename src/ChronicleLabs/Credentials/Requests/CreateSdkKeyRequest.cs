using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateSdkKeyRequest
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("scopes")]
    public IEnumerable<CreateSdkKeyRequestScopesItem> Scopes { get; set; } =
        new List<CreateSdkKeyRequestScopesItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
