using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(ListBacktestJobsResponseRunsItemStatus.ListBacktestJobsResponseRunsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListBacktestJobsResponseRunsItemStatus : IStringEnum
{
    public static readonly ListBacktestJobsResponseRunsItemStatus Running = new(Values.Running);

    public static readonly ListBacktestJobsResponseRunsItemStatus Done = new(Values.Done);

    public static readonly ListBacktestJobsResponseRunsItemStatus Paused = new(Values.Paused);

    public static readonly ListBacktestJobsResponseRunsItemStatus Scheduled = new(Values.Scheduled);

    public static readonly ListBacktestJobsResponseRunsItemStatus Draft = new(Values.Draft);

    public static readonly ListBacktestJobsResponseRunsItemStatus Failed = new(Values.Failed);

    public static readonly ListBacktestJobsResponseRunsItemStatus Cancelled = new(Values.Cancelled);

    public ListBacktestJobsResponseRunsItemStatus(string value)
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
    public static ListBacktestJobsResponseRunsItemStatus FromCustom(string value)
    {
        return new ListBacktestJobsResponseRunsItemStatus(value);
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

    public static bool operator ==(ListBacktestJobsResponseRunsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListBacktestJobsResponseRunsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListBacktestJobsResponseRunsItemStatus value) =>
        value.Value;

    public static explicit operator ListBacktestJobsResponseRunsItemStatus(string value) =>
        new(value);

    internal class ListBacktestJobsResponseRunsItemStatusSerializer
        : JsonConverter<ListBacktestJobsResponseRunsItemStatus>
    {
        public override ListBacktestJobsResponseRunsItemStatus Read(
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
            return new ListBacktestJobsResponseRunsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListBacktestJobsResponseRunsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListBacktestJobsResponseRunsItemStatus ReadAsPropertyName(
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
            return new ListBacktestJobsResponseRunsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListBacktestJobsResponseRunsItemStatus value,
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
