using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskPageItemsItemStatus.TaskPageItemsItemStatusSerializer))]
[Serializable]
public readonly record struct TaskPageItemsItemStatus : IStringEnum
{
    public static readonly TaskPageItemsItemStatus Ok = new(Values.Ok);

    public static readonly TaskPageItemsItemStatus Warn = new(Values.Warn);

    public static readonly TaskPageItemsItemStatus Error = new(Values.Error);

    public TaskPageItemsItemStatus(string value)
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
    public static TaskPageItemsItemStatus FromCustom(string value)
    {
        return new TaskPageItemsItemStatus(value);
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

    public static bool operator ==(TaskPageItemsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskPageItemsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskPageItemsItemStatus value) => value.Value;

    public static explicit operator TaskPageItemsItemStatus(string value) => new(value);

    internal class TaskPageItemsItemStatusSerializer : JsonConverter<TaskPageItemsItemStatus>
    {
        public override TaskPageItemsItemStatus Read(
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
            return new TaskPageItemsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskPageItemsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskPageItemsItemStatus ReadAsPropertyName(
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
            return new TaskPageItemsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskPageItemsItemStatus value,
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
        public const string Ok = "ok";

        public const string Warn = "warn";

        public const string Error = "error";
    }
}
