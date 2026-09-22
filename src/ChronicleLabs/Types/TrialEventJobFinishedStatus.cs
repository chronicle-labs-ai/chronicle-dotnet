using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TrialEventJobFinishedStatus.TrialEventJobFinishedStatusSerializer))]
[Serializable]
public readonly record struct TrialEventJobFinishedStatus : IStringEnum
{
    public static readonly TrialEventJobFinishedStatus Pending = new(Values.Pending);

    public static readonly TrialEventJobFinishedStatus Running = new(Values.Running);

    public static readonly TrialEventJobFinishedStatus Succeeded = new(Values.Succeeded);

    public static readonly TrialEventJobFinishedStatus Failed = new(Values.Failed);

    public static readonly TrialEventJobFinishedStatus Cancelled = new(Values.Cancelled);

    public TrialEventJobFinishedStatus(string value)
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
    public static TrialEventJobFinishedStatus FromCustom(string value)
    {
        return new TrialEventJobFinishedStatus(value);
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

    public static bool operator ==(TrialEventJobFinishedStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TrialEventJobFinishedStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TrialEventJobFinishedStatus value) => value.Value;

    public static explicit operator TrialEventJobFinishedStatus(string value) => new(value);

    internal class TrialEventJobFinishedStatusSerializer
        : JsonConverter<TrialEventJobFinishedStatus>
    {
        public override TrialEventJobFinishedStatus Read(
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
            return new TrialEventJobFinishedStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TrialEventJobFinishedStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TrialEventJobFinishedStatus ReadAsPropertyName(
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
            return new TrialEventJobFinishedStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TrialEventJobFinishedStatus value,
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
