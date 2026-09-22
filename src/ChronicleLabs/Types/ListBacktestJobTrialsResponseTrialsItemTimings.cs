using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Per-phase timing bookkeeping. Each pair is `(started_at, finished_at)`; `None` until that phase starts/ends.
/// </summary>
[Serializable]
public record ListBacktestJobTrialsResponseTrialsItemTimings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agentRunFinishedAt")]
    public DateTime? AgentRunFinishedAt { get; set; }

    [JsonPropertyName("agentRunStartedAt")]
    public DateTime? AgentRunStartedAt { get; set; }

    [JsonPropertyName("agentSetupFinishedAt")]
    public DateTime? AgentSetupFinishedAt { get; set; }

    [JsonPropertyName("agentSetupStartedAt")]
    public DateTime? AgentSetupStartedAt { get; set; }

    [JsonPropertyName("envSetupFinishedAt")]
    public DateTime? EnvSetupFinishedAt { get; set; }

    [JsonPropertyName("envSetupStartedAt")]
    public DateTime? EnvSetupStartedAt { get; set; }

    [JsonPropertyName("verifierFinishedAt")]
    public DateTime? VerifierFinishedAt { get; set; }

    [JsonPropertyName("verifierStartedAt")]
    public DateTime? VerifierStartedAt { get; set; }

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
