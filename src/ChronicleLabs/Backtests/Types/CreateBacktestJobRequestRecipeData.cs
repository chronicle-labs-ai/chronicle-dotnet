using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateBacktestJobRequestRecipeData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Populated only when `kind == "dataset"`.
    /// </summary>
    [JsonPropertyName("dataset")]
    public string? Dataset { get; set; }

    [JsonPropertyName("datasetLabel")]
    public string? DatasetLabel { get; set; }

    [JsonPropertyName("kind")]
    public required CreateBacktestJobRequestRecipeDataKind Kind { get; set; }

    /// <summary>
    /// Optional name the user wants to save this composed dataset as. `null` (vs absent) tells the UI the user opted out of saving.
    /// </summary>
    [JsonPropertyName("savedAs")]
    public string? SavedAs { get; set; }

    [JsonPropertyName("scenarios")]
    public IEnumerable<CreateBacktestJobRequestRecipeDataScenariosItem> Scenarios { get; set; } =
        new List<CreateBacktestJobRequestRecipeDataScenariosItem>();

    [JsonPropertyName("sources")]
    public IEnumerable<CreateBacktestJobRequestRecipeDataSourcesItem> Sources { get; set; } =
        new List<CreateBacktestJobRequestRecipeDataSourcesItem>();

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
