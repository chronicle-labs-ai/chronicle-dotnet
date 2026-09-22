using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record RecordAgentRunsRequestRunsItemResponseUsage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("cachedInputTokens")]
    public uint? CachedInputTokens { get; set; }

    [JsonPropertyName("inputTokens")]
    public uint? InputTokens { get; set; }

    [JsonPropertyName("outputTokens")]
    public uint? OutputTokens { get; set; }

    [JsonPropertyName("reasoningTokens")]
    public uint? ReasoningTokens { get; set; }

    [JsonPropertyName("totalTokens")]
    public uint? TotalTokens { get; set; }

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
