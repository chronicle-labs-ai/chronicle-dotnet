using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobResponseRunStatus.CreateBacktestJobResponseRunStatusSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobResponseRunStatus : IStringEnum
{
    public static readonly CreateBacktestJobResponseRunStatus Running = new(Values.Running);

    public static readonly CreateBacktestJobResponseRunStatus Done = new(Values.Done);

    public static readonly CreateBacktestJobResponseRunStatus Paused = new(Values.Paused);

    public static readonly CreateBacktestJobResponseRunStatus Scheduled = new(Values.Scheduled);

    public static readonly CreateBacktestJobResponseRunStatus Draft = new(Values.Draft);

    public static readonly CreateBacktestJobResponseRunStatus Failed = new(Values.Failed);

    public static readonly CreateBacktestJobResponseRunStatus Cancelled = new(Values.Cancelled);

    public CreateBacktestJobResponseRunStatus(string value)
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
    public static CreateBacktestJobResponseRunStatus FromCustom(string value)
    {
        return new CreateBacktestJobResponseRunStatus(value);
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

    public static bool operator ==(CreateBacktestJobResponseRunStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBacktestJobResponseRunStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobResponseRunStatus value) => value.Value;

    public static explicit operator CreateBacktestJobResponseRunStatus(string value) => new(value);

    internal class CreateBacktestJobResponseRunStatusSerializer
        : JsonConverter<CreateBacktestJobResponseRunStatus>
    {
        public override CreateBacktestJobResponseRunStatus Read(
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
            return new CreateBacktestJobResponseRunStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobResponseRunStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobResponseRunStatus ReadAsPropertyName(
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
            return new CreateBacktestJobResponseRunStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobResponseRunStatus value,
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
