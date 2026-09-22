using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Retry policy applied to transient trial failures (network errors, sandbox-create timeouts). Mirrors Harbor's `RetryConfig`. Pass `null` on the wire (`None` here) to fall back to defaults.
/// </summary>
[Serializable]
public record BacktestJobDetailResponseJobRetryConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Exception kinds that explicitly should not be retried even if otherwise matched by `include_exceptions`.
    /// </summary>
    [JsonPropertyName("excludeExceptions")]
    public IEnumerable<string>? ExcludeExceptions { get; set; }

    /// <summary>
    /// When set, only exception kinds in this list trigger a retry. `None` means "retry every transient kind".
    /// </summary>
    [JsonPropertyName("includeExceptions")]
    public IEnumerable<string>? IncludeExceptions { get; set; }

    [JsonPropertyName("maxRetries")]
    public required uint MaxRetries { get; set; }

    [JsonPropertyName("maxWaitSec")]
    public required double MaxWaitSec { get; set; }

    [JsonPropertyName("minWaitSec")]
    public required double MinWaitSec { get; set; }

    [JsonPropertyName("waitMultiplier")]
    public required double WaitMultiplier { get; set; }

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
