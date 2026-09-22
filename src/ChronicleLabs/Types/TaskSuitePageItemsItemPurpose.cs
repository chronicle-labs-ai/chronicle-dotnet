using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskSuitePageItemsItemPurpose.TaskSuitePageItemsItemPurposeSerializer))]
[Serializable]
public readonly record struct TaskSuitePageItemsItemPurpose : IStringEnum
{
    public static readonly TaskSuitePageItemsItemPurpose Eval = new(Values.Eval);

    public static readonly TaskSuitePageItemsItemPurpose Training = new(Values.Training);

    public static readonly TaskSuitePageItemsItemPurpose Replay = new(Values.Replay);

    public static readonly TaskSuitePageItemsItemPurpose Review = new(Values.Review);

    public TaskSuitePageItemsItemPurpose(string value)
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
    public static TaskSuitePageItemsItemPurpose FromCustom(string value)
    {
        return new TaskSuitePageItemsItemPurpose(value);
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

    public static bool operator ==(TaskSuitePageItemsItemPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskSuitePageItemsItemPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuitePageItemsItemPurpose value) => value.Value;

    public static explicit operator TaskSuitePageItemsItemPurpose(string value) => new(value);

    internal class TaskSuitePageItemsItemPurposeSerializer
        : JsonConverter<TaskSuitePageItemsItemPurpose>
    {
        public override TaskSuitePageItemsItemPurpose Read(
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
            return new TaskSuitePageItemsItemPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuitePageItemsItemPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuitePageItemsItemPurpose ReadAsPropertyName(
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
            return new TaskSuitePageItemsItemPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuitePageItemsItemPurpose value,
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
        public const string Eval = "eval";

        public const string Training = "training";

        public const string Replay = "replay";

        public const string Review = "review";
    }
}
