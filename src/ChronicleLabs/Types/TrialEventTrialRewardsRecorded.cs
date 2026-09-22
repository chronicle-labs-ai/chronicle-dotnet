using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// A trial wrote a final reward set; the dashboard's metrics table updates incrementally.
/// </summary>
[Serializable]
public record TrialEventTrialRewardsRecorded : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("job_id")]
    public required string JobId { get; set; }

    [JsonPropertyName("rewards")]
    public Dictionary<string, double> Rewards { get; set; } = new Dictionary<string, double>();

    [JsonPropertyName("trial_id")]
    public required string TrialId { get; set; }

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
