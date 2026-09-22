using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Reference to the environment a run will execute in. Mirrors the shape used by `EnvironmentsManager` (`SandboxEnvironment`) but without the heavy detail snapshot — the recipe only needs the identity + status to render summary chrome.
/// </summary>
[Serializable]
public record BacktestsAvailabilityEnvironmentsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether this environment is a freshly cloned ephemeral sandbox or a saved long-lived environment.
    /// </summary>
    [JsonPropertyName("ephemeral")]
    public bool? Ephemeral { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("snapshotId")]
    public string? SnapshotId { get; set; }

    [JsonPropertyName("snapshotLabel")]
    public string? SnapshotLabel { get; set; }

    /// <summary>
    /// Mirror of `SandboxRuntimeStatus` strings ("started", "stopped", …). Kept loose so callers don't need to import the environments package.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

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
