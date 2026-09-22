using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record SetTaskVerifiersRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string MembershipId { get; set; }

    [JsonPropertyName("verifiers")]
    public IEnumerable<SetTaskVerifiersRequestVerifiersItem> Verifiers { get; set; } =
        new List<SetTaskVerifiersRequestVerifiersItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
