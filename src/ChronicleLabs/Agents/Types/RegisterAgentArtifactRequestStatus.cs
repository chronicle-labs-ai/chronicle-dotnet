using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(RegisterAgentArtifactRequestStatus.RegisterAgentArtifactRequestStatusSerializer)
)]
[Serializable]
public readonly record struct RegisterAgentArtifactRequestStatus : IStringEnum
{
    public static readonly RegisterAgentArtifactRequestStatus Current = new(Values.Current);

    public static readonly RegisterAgentArtifactRequestStatus Stable = new(Values.Stable);

    public static readonly RegisterAgentArtifactRequestStatus Deprecated = new(Values.Deprecated);

    public static readonly RegisterAgentArtifactRequestStatus Draft = new(Values.Draft);

    public RegisterAgentArtifactRequestStatus(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static RegisterAgentArtifactRequestStatus FromCustom(string value)
    {
        return new RegisterAgentArtifactRequestStatus(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(RegisterAgentArtifactRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RegisterAgentArtifactRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RegisterAgentArtifactRequestStatus value) => value.Value;

    public static explicit operator RegisterAgentArtifactRequestStatus(string value) => new(value);

    internal class RegisterAgentArtifactRequestStatusSerializer
        : JsonConverter<RegisterAgentArtifactRequestStatus>
    {
        public override RegisterAgentArtifactRequestStatus Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new RegisterAgentArtifactRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RegisterAgentArtifactRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RegisterAgentArtifactRequestStatus ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new RegisterAgentArtifactRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RegisterAgentArtifactRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Current = "current";

        public const string Stable = "stable";

        public const string Deprecated = "deprecated";

        public const string Draft = "draft";
    }
}
