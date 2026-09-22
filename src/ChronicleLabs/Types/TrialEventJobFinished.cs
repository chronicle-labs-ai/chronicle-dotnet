using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// The job reached a terminal status. Carries a verdict so the list view can render without an extra fetch.
/// </summary>
[Serializable]
public record TrialEventJobFinished : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("job_id")]
    public required string JobId { get; set; }

    /// <summary>
    /// Lifecycle state of an entire `BacktestJob`. Maps 1:1 onto the `status` column in `migrations/013_create_backtest_runtime.sql`.
    /// </summary>
    [JsonPropertyName("status")]
    public required TrialEventJobFinishedStatus Status { get; set; }

    [JsonPropertyName("verdict")]
    public string? Verdict { get; set; }

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
