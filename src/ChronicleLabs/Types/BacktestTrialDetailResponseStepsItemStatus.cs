using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseStepsItemStatus.BacktestTrialDetailResponseStepsItemStatusSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseStepsItemStatus : IStringEnum
{
    public static readonly BacktestTrialDetailResponseStepsItemStatus Ok = new(Values.Ok);

    public static readonly BacktestTrialDetailResponseStepsItemStatus Warn = new(Values.Warn);

    public static readonly BacktestTrialDetailResponseStepsItemStatus Error = new(Values.Error);

    public BacktestTrialDetailResponseStepsItemStatus(string value)
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
    public static BacktestTrialDetailResponseStepsItemStatus FromCustom(string value)
    {
        return new BacktestTrialDetailResponseStepsItemStatus(value);
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

    public static bool operator ==(
        BacktestTrialDetailResponseStepsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestTrialDetailResponseStepsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BacktestTrialDetailResponseStepsItemStatus value) =>
        value.Value;

    public static explicit operator BacktestTrialDetailResponseStepsItemStatus(string value) =>
        new(value);

    internal class BacktestTrialDetailResponseStepsItemStatusSerializer
        : JsonConverter<BacktestTrialDetailResponseStepsItemStatus>
    {
        public override BacktestTrialDetailResponseStepsItemStatus Read(
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
            return new BacktestTrialDetailResponseStepsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseStepsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseStepsItemStatus ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseStepsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseStepsItemStatus value,
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
        public const string Ok = "ok";

        public const string Warn = "warn";

        public const string Error = "error";
    }
}
