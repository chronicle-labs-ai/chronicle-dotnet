using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record AgentVersionSummaryArtifactProvenance : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("aiSdkVersion")]
    public string? AiSdkVersion { get; set; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("dependencyLockHash")]
    public string? DependencyLockHash { get; set; }

    [JsonPropertyName("frameworkVersion")]
    public string? FrameworkVersion { get; set; }

    [JsonPropertyName("gitSha")]
    public string? GitSha { get; set; }

    [JsonPropertyName("publishedBy")]
    public string? PublishedBy { get; set; }

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
