using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CreateBacktestJobRequestRecipe : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// 1..N agents under test. The first is treated as the comparison baseline by `BacktestResults`.
    /// </summary>
    [JsonPropertyName("agents")]
    public IEnumerable<CreateBacktestJobRequestRecipeAgentsItem> Agents { get; set; } =
        new List<CreateBacktestJobRequestRecipeAgentsItem>();

    [JsonPropertyName("data")]
    public required CreateBacktestJobRequestRecipeData Data { get; set; }

    /// <summary>
    /// Optional environment the run targets. Pipeline step 03 sets this; consumers without an environment fall back to the default ephemeral sandbox.
    /// </summary>
    [JsonPropertyName("environment")]
    public CreateBacktestJobRequestRecipeEnvironment? Environment { get; set; }

    [JsonPropertyName("graders")]
    public IEnumerable<CreateBacktestJobRequestRecipeGradersItem> Graders { get; set; } =
        new List<CreateBacktestJobRequestRecipeGradersItem>();

    [JsonPropertyName("mode")]
    public required CreateBacktestJobRequestRecipeMode Mode { get; set; }

    /// <summary>
    /// Free-text run name shown in the recipe header + top nav.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Optional pinned trace seed; used by the Replay preset to reproduce a single trace as the focal point of the run.
    /// </summary>
    [JsonPropertyName("seed")]
    public string? Seed { get; set; }

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
