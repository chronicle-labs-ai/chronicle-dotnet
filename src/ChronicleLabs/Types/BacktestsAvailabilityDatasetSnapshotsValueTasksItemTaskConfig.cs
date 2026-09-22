using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Runtime knobs a task carries, mirroring the `[agent]`, `[verifier]` and `[environment]` tables of a Harbor `task.toml`. Every field is optional; the server policy fills defaults at launch.
/// </summary>
[Serializable]
public record BacktestsAvailabilityDatasetSnapshotsValueTasksItemTaskConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("agentTimeoutSec")]
    public double? AgentTimeoutSec { get; set; }

    /// <summary>
    /// Network policy for the agent sandbox, mirroring Harbor's `[environment].network_mode`.
    /// </summary>
    [JsonPropertyName("networkMode")]
    public BacktestsAvailabilityDatasetSnapshotsValueTasksItemTaskConfigNetworkMode? NetworkMode { get; set; }

    [JsonPropertyName("verifierTimeoutSec")]
    public double? VerifierTimeoutSec { get; set; }

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
