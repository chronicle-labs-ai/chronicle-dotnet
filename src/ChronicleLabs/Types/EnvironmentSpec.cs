using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record EnvironmentSpec : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("datastores")]
    public IEnumerable<object>? Datastores { get; set; }

    [JsonPropertyName("interception")]
    public required EnvironmentSpecInterception Interception { get; set; }

    [JsonPropertyName("mcp")]
    public IEnumerable<EnvironmentSpecMcpItem>? Mcp { get; set; }

    [JsonPropertyName("services")]
    public IEnumerable<EnvironmentSpecServicesItem>? Services { get; set; }

    /// <summary>
    /// Twins this environment wants running (`backend/twins` models), seeded from the environment's dataset when spun up.
    /// </summary>
    [JsonPropertyName("twins")]
    public IEnumerable<EnvironmentSpecTwinsItem>? Twins { get; set; }

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
