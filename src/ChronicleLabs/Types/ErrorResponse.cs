using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// RFC 9457 problem details, served as `application/problem+json`. The `code` member is the stable machine-readable slug to branch on; `type` and `title` are stable per problem class, and `detail` varies per occurrence. The `error` and `message` members are retained for existing clients and carry the same values as `code` and `detail`. The request identifier appears both in the `x-request-id` response header, for code to read and log, and in the `request_id` member, so it survives being copied into a support thread.
/// </summary>
[Serializable]
public record ErrorResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// URI identifying the problem class
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Short summary of the problem class, stable across occurrences
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// HTTP status code, always equal to the response status
    /// </summary>
    [JsonPropertyName("status")]
    public required int Status { get; set; }

    /// <summary>
    /// Explanation specific to this occurrence
    /// </summary>
    [JsonPropertyName("detail")]
    public required string Detail { get; set; }

    /// <summary>
    /// Stable machine-readable slug to branch on
    /// </summary>
    [JsonPropertyName("code")]
    public required ErrorResponseCode Code { get; set; }

    /// <summary>
    /// Retained for existing clients. Same value as `code`.
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error { get; set; }

    /// <summary>
    /// Retained for existing clients. Same value as `detail`.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

    /// <summary>
    /// Whether the same request may succeed when retried without modification
    /// </summary>
    [JsonPropertyName("retryable")]
    public required bool Retryable { get; set; }

    /// <summary>
    /// Same value as the `x-request-id` response header. Quote it when reporting a problem; it identifies the exact request in our logs.
    /// </summary>
    [JsonPropertyName("request_id")]
    public string? RequestId { get; set; }

    [JsonPropertyName("details")]
    public object? Details { get; set; }

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
