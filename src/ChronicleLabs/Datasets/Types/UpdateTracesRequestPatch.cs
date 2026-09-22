using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Patch to apply to one or more memberships. Nullable annotations preserve the same three states as [`PatchField`]: explicit JSON `null` clears while omission is a no-op.
/// </summary>
[Serializable]
public record UpdateTracesRequestPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// New cluster id, or `null` to drop the trace from any cluster.
    /// </summary>
    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    /// <summary>
    /// Replace the membership note, or `null` to clear it.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// New split, or `null` to mark unassigned.
    /// </summary>
    [JsonPropertyName("split")]
    public UpdateTracesRequestPatchSplit? Split { get; set; }

    /// <summary>
    /// Health status of a trace as judged by the dataset owner.
    /// </summary>
    [JsonPropertyName("status")]
    public UpdateTracesRequestPatchStatus? Status { get; set; }

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
