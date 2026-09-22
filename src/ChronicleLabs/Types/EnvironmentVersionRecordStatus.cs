using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(EnvironmentVersionRecordStatus.EnvironmentVersionRecordStatusSerializer))]
[Serializable]
public readonly record struct EnvironmentVersionRecordStatus : IStringEnum
{
    public static readonly EnvironmentVersionRecordStatus Draft = new(Values.Draft);

    public static readonly EnvironmentVersionRecordStatus Published = new(Values.Published);

    public static readonly EnvironmentVersionRecordStatus Archived = new(Values.Archived);

    public EnvironmentVersionRecordStatus(string value)
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
    public static EnvironmentVersionRecordStatus FromCustom(string value)
    {
        return new EnvironmentVersionRecordStatus(value);
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

    public static bool operator ==(EnvironmentVersionRecordStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EnvironmentVersionRecordStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EnvironmentVersionRecordStatus value) => value.Value;

    public static explicit operator EnvironmentVersionRecordStatus(string value) => new(value);

    internal class EnvironmentVersionRecordStatusSerializer
        : JsonConverter<EnvironmentVersionRecordStatus>
    {
        public override EnvironmentVersionRecordStatus Read(
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
            return new EnvironmentVersionRecordStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EnvironmentVersionRecordStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EnvironmentVersionRecordStatus ReadAsPropertyName(
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
            return new EnvironmentVersionRecordStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EnvironmentVersionRecordStatus value,
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
        public const string Draft = "draft";

        public const string Published = "published";

        public const string Archived = "archived";
    }
}
