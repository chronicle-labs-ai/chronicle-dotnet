using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record GetAgentChatSessionRequest
{
    [JsonIgnore]
    public required string Name { get; set; }

    [JsonIgnore]
    public required string SessionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
