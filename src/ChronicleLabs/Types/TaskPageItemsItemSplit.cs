using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskPageItemsItemSplit.TaskPageItemsItemSplitSerializer))]
[Serializable]
public readonly record struct TaskPageItemsItemSplit : IStringEnum
{
    public static readonly TaskPageItemsItemSplit Train = new(Values.Train);

    public static readonly TaskPageItemsItemSplit Validation = new(Values.Validation);

    public static readonly TaskPageItemsItemSplit Test = new(Values.Test);

    public TaskPageItemsItemSplit(string value)
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
    public static TaskPageItemsItemSplit FromCustom(string value)
    {
        return new TaskPageItemsItemSplit(value);
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

    public static bool operator ==(TaskPageItemsItemSplit value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskPageItemsItemSplit value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskPageItemsItemSplit value) => value.Value;

    public static explicit operator TaskPageItemsItemSplit(string value) => new(value);

    internal class TaskPageItemsItemSplitSerializer : JsonConverter<TaskPageItemsItemSplit>
    {
        public override TaskPageItemsItemSplit Read(
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
            return new TaskPageItemsItemSplit(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskPageItemsItemSplit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskPageItemsItemSplit ReadAsPropertyName(
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
            return new TaskPageItemsItemSplit(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskPageItemsItemSplit value,
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
        public const string Train = "train";

        public const string Validation = "validation";

        public const string Test = "test";
    }
}
