using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentSnapshot : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("hashIndex")]
    public IEnumerable<AgentSnapshotHashIndexItem> HashIndex { get; set; } =
        new List<AgentSnapshotHashIndexItem>();

    [JsonPropertyName("runs")]
    public IEnumerable<AgentSnapshotRunsItem> Runs { get; set; } =
        new List<AgentSnapshotRunsItem>();

    [JsonPropertyName("summary")]
    public required AgentSnapshotSummary Summary { get; set; }

    [JsonPropertyName("versions")]
    public IEnumerable<AgentSnapshotVersionsItem> Versions { get; set; } =
        new List<AgentSnapshotVersionsItem>();

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
