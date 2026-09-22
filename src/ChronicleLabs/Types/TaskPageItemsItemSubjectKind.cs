using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskPageItemsItemSubjectKind.TaskPageItemsItemSubjectKindSerializer))]
[Serializable]
public readonly record struct TaskPageItemsItemSubjectKind : IStringEnum
{
    public static readonly TaskPageItemsItemSubjectKind Trace = new(Values.Trace);

    public static readonly TaskPageItemsItemSubjectKind Event = new(Values.Event);

    public static readonly TaskPageItemsItemSubjectKind Task = new(Values.Task);

    public TaskPageItemsItemSubjectKind(string value)
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
    public static TaskPageItemsItemSubjectKind FromCustom(string value)
    {
        return new TaskPageItemsItemSubjectKind(value);
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

    public static bool operator ==(TaskPageItemsItemSubjectKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskPageItemsItemSubjectKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskPageItemsItemSubjectKind value) => value.Value;

    public static explicit operator TaskPageItemsItemSubjectKind(string value) => new(value);

    internal class TaskPageItemsItemSubjectKindSerializer
        : JsonConverter<TaskPageItemsItemSubjectKind>
    {
        public override TaskPageItemsItemSubjectKind Read(
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
            return new TaskPageItemsItemSubjectKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskPageItemsItemSubjectKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskPageItemsItemSubjectKind ReadAsPropertyName(
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
            return new TaskPageItemsItemSubjectKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskPageItemsItemSubjectKind value,
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
        public const string Trace = "trace";

        public const string Event = "event";

        public const string Task = "task";
    }
}
