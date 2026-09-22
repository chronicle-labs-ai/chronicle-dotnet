using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(BacktestJobDetailResponseJobMode.BacktestJobDetailResponseJobModeSerializer))]
[Serializable]
public readonly record struct BacktestJobDetailResponseJobMode : IStringEnum
{
    public static readonly BacktestJobDetailResponseJobMode Replay = new(Values.Replay);

    public static readonly BacktestJobDetailResponseJobMode Compare = new(Values.Compare);

    public static readonly BacktestJobDetailResponseJobMode Regression = new(Values.Regression);

    public static readonly BacktestJobDetailResponseJobMode Suite = new(Values.Suite);

    public BacktestJobDetailResponseJobMode(string value)
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
    public static BacktestJobDetailResponseJobMode FromCustom(string value)
    {
        return new BacktestJobDetailResponseJobMode(value);
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

    public static bool operator ==(BacktestJobDetailResponseJobMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BacktestJobDetailResponseJobMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BacktestJobDetailResponseJobMode value) => value.Value;

    public static explicit operator BacktestJobDetailResponseJobMode(string value) => new(value);

    internal class BacktestJobDetailResponseJobModeSerializer
        : JsonConverter<BacktestJobDetailResponseJobMode>
    {
        public override BacktestJobDetailResponseJobMode Read(
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
            return new BacktestJobDetailResponseJobMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseJobMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestJobDetailResponseJobMode ReadAsPropertyName(
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
            return new BacktestJobDetailResponseJobMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseJobMode value,
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
