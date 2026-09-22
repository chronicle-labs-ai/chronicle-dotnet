using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(BacktestJobDetailResponseRunMode.BacktestJobDetailResponseRunModeSerializer))]
[Serializable]
public readonly record struct BacktestJobDetailResponseRunMode : IStringEnum
{
    public static readonly BacktestJobDetailResponseRunMode Replay = new(Values.Replay);

    public static readonly BacktestJobDetailResponseRunMode Compare = new(Values.Compare);

    public static readonly BacktestJobDetailResponseRunMode Regression = new(Values.Regression);

    public static readonly BacktestJobDetailResponseRunMode Suite = new(Values.Suite);

    public BacktestJobDetailResponseRunMode(string value)
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
    public static BacktestJobDetailResponseRunMode FromCustom(string value)
    {
        return new BacktestJobDetailResponseRunMode(value);
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

    public static bool operator ==(BacktestJobDetailResponseRunMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BacktestJobDetailResponseRunMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BacktestJobDetailResponseRunMode value) => value.Value;

    public static explicit operator BacktestJobDetailResponseRunMode(string value) => new(value);

    internal class BacktestJobDetailResponseRunModeSerializer
        : JsonConverter<BacktestJobDetailResponseRunMode>
    {
        public override BacktestJobDetailResponseRunMode Read(
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
            return new BacktestJobDetailResponseRunMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseRunMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestJobDetailResponseRunMode ReadAsPropertyName(
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
            return new BacktestJobDetailResponseRunMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseRunMode value,
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
