using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[Serializable]
public record CompileEnvironmentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("environmentId")]
    public required string EnvironmentId { get; set; }

    [JsonPropertyName("environmentSlug")]
    public required string EnvironmentSlug { get; set; }

    [JsonPropertyName("versionId")]
    public required string VersionId { get; set; }

    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("tenantId")]
    public required string TenantId { get; set; }

    [JsonPropertyName("datasetSnapshotId")]
    public required string DatasetSnapshotId { get; set; }

    [JsonPropertyName("scenarioId")]
    public required string ScenarioId { get; set; }

    [JsonPropertyName("bundleId")]
    public required string BundleId { get; set; }

    [JsonPropertyName("sha256")]
    public required string Sha256 { get; set; }

    [JsonPropertyName("uri")]
    public required string Uri { get; set; }

    [JsonPropertyName("packageUri")]
    public required string PackageUri { get; set; }

    [JsonPropertyName("rootDir")]
    public required string RootDir { get; set; }

    [JsonPropertyName("sizeBytes")]
    public required long SizeBytes { get; set; }

    [JsonPropertyName("warnings")]
    public IEnumerable<string> Warnings { get; set; } = new List<string>();

    [JsonPropertyName("files")]
    public IEnumerable<string> Files { get; set; } = new List<string>();

    [JsonPropertyName("manifest")]
    public Dictionary<string, object?> Manifest { get; set; } = new Dictionary<string, object?>();

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
