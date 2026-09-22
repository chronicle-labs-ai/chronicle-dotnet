using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record BacktestJobDetailResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Row projection of `"BacktestJob"`.
    /// </summary>
    [JsonPropertyName("job")]
    public required BacktestJobDetailResponseJob Job { get; set; }

    /// <summary>
    /// Compact projection of a backtest run rendered on the list view. Combines the recipe identity (mode, environment, agents, dataset) with run lifecycle metadata (status, verdict, divergences).
    /// </summary>
    [JsonPropertyName("run")]
    public required BacktestJobDetailResponseRun Run { get; set; }

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
