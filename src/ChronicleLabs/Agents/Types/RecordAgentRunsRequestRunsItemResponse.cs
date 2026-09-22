using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RecordAgentRunsRequestRunsItemResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("bodyHash")]
    public string? BodyHash { get; set; }

    [JsonPropertyName("finishReason")]
    public string? FinishReason { get; set; }

    /// <summary>
    /// Subset of headers preserved for the run drawer.
    /// </summary>
    [JsonPropertyName("headers")]
    public Dictionary<string, string?>? Headers { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("modelId")]
    public string? ModelId { get; set; }

    [JsonPropertyName("modelMetadata")]
    public Dictionary<string, object?>? ModelMetadata { get; set; }

    [JsonPropertyName("providerMetadata")]
    public Dictionary<string, object?>? ProviderMetadata { get; set; }

    [JsonPropertyName("usage")]
    public RecordAgentRunsRequestRunsItemResponseUsage? Usage { get; set; }

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
