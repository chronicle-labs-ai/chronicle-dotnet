using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Code handler snapshot — required when `kind` is `code`.
/// </summary>
[Serializable]
public record CreateBacktestJobRequestRecipeGradersItemCode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Language of a code scorer. Handlers run inside the trial's trusted verifier sandbox: Python via `python3`, TypeScript via `node` (&gt;= 22.6, type-stripping) — both shipped in the sandbox runtime image.
    /// </summary>
    [JsonPropertyName("language")]
    public required CreateBacktestJobRequestRecipeGradersItemCodeLanguage Language { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

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
