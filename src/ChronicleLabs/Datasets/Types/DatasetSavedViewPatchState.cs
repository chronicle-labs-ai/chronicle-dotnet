using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record DatasetSavedViewPatchState : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("density")]
    public string? Density { get; set; }

    [JsonPropertyName("displayProperties")]
    public IEnumerable<string>? DisplayProperties { get; set; }

    [JsonPropertyName("filters")]
    public IEnumerable<DatasetSavedViewPatchStateFiltersItem>? Filters { get; set; }

    [JsonPropertyName("groupBy")]
    public string? GroupBy { get; set; }

    [JsonPropertyName("lens")]
    public string? Lens { get; set; }

    /// <summary>
    /// Deprecated since the table moved to TanStack multi-column sort. New views write `sorting`; this stays as a back-compat fallback for views captured before the migration.
    /// </summary>
    [JsonPropertyName("ordering")]
    public string? Ordering { get; set; }

    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("showEmptyGroups")]
    public bool? ShowEmptyGroups { get; set; }

    [JsonPropertyName("sorting")]
    public IEnumerable<DatasetSavedViewPatchStateSortingItem>? Sorting { get; set; }

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
