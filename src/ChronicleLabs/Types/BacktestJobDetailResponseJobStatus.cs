using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestJobDetailResponseJobStatus.BacktestJobDetailResponseJobStatusSerializer)
)]
[Serializable]
public readonly record struct BacktestJobDetailResponseJobStatus : IStringEnum
{
    public static readonly BacktestJobDetailResponseJobStatus Pending = new(Values.Pending);

    public static readonly BacktestJobDetailResponseJobStatus Running = new(Values.Running);

    public static readonly BacktestJobDetailResponseJobStatus Succeeded = new(Values.Succeeded);

    public static readonly BacktestJobDetailResponseJobStatus Failed = new(Values.Failed);

    public static readonly BacktestJobDetailResponseJobStatus Cancelled = new(Values.Cancelled);

    public BacktestJobDetailResponseJobStatus(string value)
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
    public static BacktestJobDetailResponseJobStatus FromCustom(string value)
    {
        return new BacktestJobDetailResponseJobStatus(value);
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

    public static bool operator ==(BacktestJobDetailResponseJobStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BacktestJobDetailResponseJobStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BacktestJobDetailResponseJobStatus value) => value.Value;

    public static explicit operator BacktestJobDetailResponseJobStatus(string value) => new(value);

    internal class BacktestJobDetailResponseJobStatusSerializer
        : JsonConverter<BacktestJobDetailResponseJobStatus>
    {
        public override BacktestJobDetailResponseJobStatus Read(
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
            return new BacktestJobDetailResponseJobStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseJobStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestJobDetailResponseJobStatus ReadAsPropertyName(
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
            return new BacktestJobDetailResponseJobStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseJobStatus value,
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
        public const string Pending = "pending";

        public const string Running = "running";

        public const string Succeeded = "succeeded";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
