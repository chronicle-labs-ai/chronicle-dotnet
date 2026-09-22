using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TrialEventTrialFinishedStatus.TrialEventTrialFinishedStatusSerializer))]
[Serializable]
public readonly record struct TrialEventTrialFinishedStatus : IStringEnum
{
    public static readonly TrialEventTrialFinishedStatus Pending = new(Values.Pending);

    public static readonly TrialEventTrialFinishedStatus Setup = new(Values.Setup);

    public static readonly TrialEventTrialFinishedStatus Running = new(Values.Running);

    public static readonly TrialEventTrialFinishedStatus Verifying = new(Values.Verifying);

    public static readonly TrialEventTrialFinishedStatus Succeeded = new(Values.Succeeded);

    public static readonly TrialEventTrialFinishedStatus Failed = new(Values.Failed);

    public static readonly TrialEventTrialFinishedStatus Cancelled = new(Values.Cancelled);

    public TrialEventTrialFinishedStatus(string value)
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
    public static TrialEventTrialFinishedStatus FromCustom(string value)
    {
        return new TrialEventTrialFinishedStatus(value);
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

    public static bool operator ==(TrialEventTrialFinishedStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TrialEventTrialFinishedStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TrialEventTrialFinishedStatus value) => value.Value;

    public static explicit operator TrialEventTrialFinishedStatus(string value) => new(value);

    internal class TrialEventTrialFinishedStatusSerializer
        : JsonConverter<TrialEventTrialFinishedStatus>
    {
        public override TrialEventTrialFinishedStatus Read(
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
            return new TrialEventTrialFinishedStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TrialEventTrialFinishedStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TrialEventTrialFinishedStatus ReadAsPropertyName(
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
            return new TrialEventTrialFinishedStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TrialEventTrialFinishedStatus value,
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
