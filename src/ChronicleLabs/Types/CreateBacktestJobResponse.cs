using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateBacktestJobResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    /// <summary>
    /// Compact projection of a backtest run rendered on the list view. Combines the recipe identity (mode, environment, agents, dataset) with run lifecycle metadata (status, verdict, divergences).
    /// </summary>
    [JsonPropertyName("run")]
    public required CreateBacktestJobResponseRun Run { get; set; }

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
