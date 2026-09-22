using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(ListBacktestJobsResponseRunsItemMode.ListBacktestJobsResponseRunsItemModeSerializer)
)]
[Serializable]
public readonly record struct ListBacktestJobsResponseRunsItemMode : IStringEnum
{
    public static readonly ListBacktestJobsResponseRunsItemMode Replay = new(Values.Replay);

    public static readonly ListBacktestJobsResponseRunsItemMode Compare = new(Values.Compare);

    public static readonly ListBacktestJobsResponseRunsItemMode Regression = new(Values.Regression);

    public static readonly ListBacktestJobsResponseRunsItemMode Suite = new(Values.Suite);

    public ListBacktestJobsResponseRunsItemMode(string value)
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
    public static ListBacktestJobsResponseRunsItemMode FromCustom(string value)
    {
        return new ListBacktestJobsResponseRunsItemMode(value);
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

    public static bool operator ==(ListBacktestJobsResponseRunsItemMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ListBacktestJobsResponseRunsItemMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ListBacktestJobsResponseRunsItemMode value) =>
        value.Value;

    public static explicit operator ListBacktestJobsResponseRunsItemMode(string value) =>
        new(value);

    internal class ListBacktestJobsResponseRunsItemModeSerializer
        : JsonConverter<ListBacktestJobsResponseRunsItemMode>
    {
        public override ListBacktestJobsResponseRunsItemMode Read(
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
            return new ListBacktestJobsResponseRunsItemMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListBacktestJobsResponseRunsItemMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListBacktestJobsResponseRunsItemMode ReadAsPropertyName(
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
            return new ListBacktestJobsResponseRunsItemMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListBacktestJobsResponseRunsItemMode value,
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
