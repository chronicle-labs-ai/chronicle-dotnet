using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CancelBacktestJobResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// True only when an active execution accepted cancellation.
    /// </summary>
    [JsonPropertyName("aborted")]
    public required bool Aborted { get; set; }

    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    /// <summary>
    /// Lifecycle state of an entire `BacktestJob`. Maps 1:1 onto the `status` column in `migrations/013_create_backtest_runtime.sql`.
    /// </summary>
    [JsonPropertyName("previousStatus")]
    public required CancelBacktestJobResponsePreviousStatus PreviousStatus { get; set; }

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
