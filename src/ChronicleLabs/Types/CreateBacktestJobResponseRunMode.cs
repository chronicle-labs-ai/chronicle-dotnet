using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(CreateBacktestJobResponseRunMode.CreateBacktestJobResponseRunModeSerializer))]
[Serializable]
public readonly record struct CreateBacktestJobResponseRunMode : IStringEnum
{
    public static readonly CreateBacktestJobResponseRunMode Replay = new(Values.Replay);

    public static readonly CreateBacktestJobResponseRunMode Compare = new(Values.Compare);

    public static readonly CreateBacktestJobResponseRunMode Regression = new(Values.Regression);

    public static readonly CreateBacktestJobResponseRunMode Suite = new(Values.Suite);

    public CreateBacktestJobResponseRunMode(string value)
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
    public static CreateBacktestJobResponseRunMode FromCustom(string value)
    {
        return new CreateBacktestJobResponseRunMode(value);
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

    public static bool operator ==(CreateBacktestJobResponseRunMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBacktestJobResponseRunMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobResponseRunMode value) => value.Value;

    public static explicit operator CreateBacktestJobResponseRunMode(string value) => new(value);

    internal class CreateBacktestJobResponseRunModeSerializer
        : JsonConverter<CreateBacktestJobResponseRunMode>
    {
        public override CreateBacktestJobResponseRunMode Read(
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
            return new CreateBacktestJobResponseRunMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobResponseRunMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobResponseRunMode ReadAsPropertyName(
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
            return new CreateBacktestJobResponseRunMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobResponseRunMode value,
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
        public const string Replay = "replay";

        public const string Compare = "compare";

        public const string Regression = "regression";

        public const string Suite = "suite";
    }
}
