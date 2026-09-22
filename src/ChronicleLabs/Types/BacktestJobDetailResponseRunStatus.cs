using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestJobDetailResponseRunStatus.BacktestJobDetailResponseRunStatusSerializer)
)]
[Serializable]
public readonly record struct BacktestJobDetailResponseRunStatus : IStringEnum
{
    public static readonly BacktestJobDetailResponseRunStatus Running = new(Values.Running);

    public static readonly BacktestJobDetailResponseRunStatus Done = new(Values.Done);

    public static readonly BacktestJobDetailResponseRunStatus Paused = new(Values.Paused);

    public static readonly BacktestJobDetailResponseRunStatus Scheduled = new(Values.Scheduled);

    public static readonly BacktestJobDetailResponseRunStatus Draft = new(Values.Draft);

    public static readonly BacktestJobDetailResponseRunStatus Failed = new(Values.Failed);

    public static readonly BacktestJobDetailResponseRunStatus Cancelled = new(Values.Cancelled);

    public BacktestJobDetailResponseRunStatus(string value)
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
    public static BacktestJobDetailResponseRunStatus FromCustom(string value)
    {
        return new BacktestJobDetailResponseRunStatus(value);
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

    public static bool operator ==(BacktestJobDetailResponseRunStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BacktestJobDetailResponseRunStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BacktestJobDetailResponseRunStatus value) => value.Value;

    public static explicit operator BacktestJobDetailResponseRunStatus(string value) => new(value);

    internal class BacktestJobDetailResponseRunStatusSerializer
        : JsonConverter<BacktestJobDetailResponseRunStatus>
    {
        public override BacktestJobDetailResponseRunStatus Read(
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
            return new BacktestJobDetailResponseRunStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseRunStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestJobDetailResponseRunStatus ReadAsPropertyName(
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
            return new BacktestJobDetailResponseRunStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseRunStatus value,
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
        public const string Running = "running";

        public const string Done = "done";

        public const string Paused = "paused";

        public const string Scheduled = "scheduled";

        public const string Draft = "draft";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
