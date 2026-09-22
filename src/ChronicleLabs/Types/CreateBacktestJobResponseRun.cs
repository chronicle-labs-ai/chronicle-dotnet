using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Compact projection of a backtest run rendered on the list view. Combines the recipe identity (mode, environment, agents, dataset) with run lifecycle metadata (status, verdict, divergences).
/// </summary>
[Serializable]
public record CreateBacktestJobResponseRun : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Agent ids participating in the run; the first is the baseline.
    /// </summary>
    [JsonPropertyName("agentIds")]
    public IEnumerable<string> AgentIds { get; set; } = new List<string>();

    /// <summary>
    /// Display label for the dataset / production window seed.
    /// </summary>
    [JsonPropertyName("datasetLabel")]
    public required string DatasetLabel { get; set; }

    /// <summary>
    /// Divergences observed (only set when status is `done` / `failed`).
    /// </summary>
    [JsonPropertyName("divergences")]
    public uint? Divergences { get; set; }

    [JsonPropertyName("environmentLabel")]
    public string? EnvironmentLabel { get; set; }

    [JsonPropertyName("hue")]
    public string? Hue { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("mode")]
    public required CreateBacktestJobResponseRunMode Mode { get; set; }

    /// <summary>
    /// Display name of the run (matches `BacktestRecipe.name`).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("scheduledFor")]
    public DateTime? ScheduledFor { get; set; }

    [JsonPropertyName("status")]
    public required CreateBacktestJobResponseRunStatus Status { get; set; }

    /// <summary>
    /// Total cases × agents; null while still drafting.
    /// </summary>
    [JsonPropertyName("totalRuns")]
    public uint? TotalRuns { get; set; }

    /// <summary>
    /// ISO timestamp of the most recent state change — drives "ago".
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

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
