using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record SendAgentChatMessageRequest
{
    [JsonIgnore]
    public required string Name { get; set; }

    [JsonIgnore]
    public required string SessionId { get; set; }

    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
