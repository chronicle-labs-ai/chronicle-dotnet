using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RefreshDatasetTaskRequest
{
    [JsonIgnore]
    public required string DatasetId { get; set; }

    [JsonIgnore]
    public required string MembershipId { get; set; }

    /// <summary>
    /// Optional caller-generated key for safely retrying a mutation.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required RefreshMembershipRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
