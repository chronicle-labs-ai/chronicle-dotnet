using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// One explicit case accepted by `POST /v1/backtests/jobs` for non-Dataset recipes. Dataset-backed requests use these entries only as a case-id selection; the server always loads the instruction and expected outcome from the pinned Dataset Version.
/// </summary>
[Serializable]
public record CreateBacktestJobRequestCasesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("caseCluster")]
    public string? CaseCluster { get; set; }

    [JsonPropertyName("caseId")]
    public required string CaseId { get; set; }

    [JsonPropertyName("expectedOutcome")]
    public string? ExpectedOutcome { get; set; }

    /// <summary>
    /// Required for composed recipes. Dataset-backed requests may omit it because the server loads canonical content from the pinned Version.
    /// </summary>
    [JsonPropertyName("instruction")]
    public string? Instruction { get; set; }

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
