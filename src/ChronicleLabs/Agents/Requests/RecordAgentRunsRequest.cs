using ChronicleLabs.Core;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RecordAgentRunsRequest
{
    [JsonPropertyName("runs")]
    public IEnumerable<RecordAgentRunsRequestRunsItem> Runs { get; set; } =
        new List<RecordAgentRunsRequestRunsItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
