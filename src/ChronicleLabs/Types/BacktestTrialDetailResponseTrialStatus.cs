using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseTrialStatus.BacktestTrialDetailResponseTrialStatusSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseTrialStatus : IStringEnum
{
    public static readonly BacktestTrialDetailResponseTrialStatus Pending = new(Values.Pending);

    public static readonly BacktestTrialDetailResponseTrialStatus Setup = new(Values.Setup);

    public static readonly BacktestTrialDetailResponseTrialStatus Running = new(Values.Running);

    public static readonly BacktestTrialDetailResponseTrialStatus Verifying = new(Values.Verifying);

    public static readonly BacktestTrialDetailResponseTrialStatus Succeeded = new(Values.Succeeded);

    public static readonly BacktestTrialDetailResponseTrialStatus Failed = new(Values.Failed);

    public static readonly BacktestTrialDetailResponseTrialStatus Cancelled = new(Values.Cancelled);

    public BacktestTrialDetailResponseTrialStatus(string value)
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
    public static BacktestTrialDetailResponseTrialStatus FromCustom(string value)
    {
        return new BacktestTrialDetailResponseTrialStatus(value);
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

    public static bool operator ==(BacktestTrialDetailResponseTrialStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BacktestTrialDetailResponseTrialStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BacktestTrialDetailResponseTrialStatus value) =>
        value.Value;

    public static explicit operator BacktestTrialDetailResponseTrialStatus(string value) =>
        new(value);

    internal class BacktestTrialDetailResponseTrialStatusSerializer
        : JsonConverter<BacktestTrialDetailResponseTrialStatus>
    {
        public override BacktestTrialDetailResponseTrialStatus Read(
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
            return new BacktestTrialDetailResponseTrialStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseTrialStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseTrialStatus ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseTrialStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseTrialStatus value,
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

        public const string Setup = "setup";

        public const string Running = "running";

        public const string Verifying = "verifying";

        public const string Succeeded = "succeeded";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
