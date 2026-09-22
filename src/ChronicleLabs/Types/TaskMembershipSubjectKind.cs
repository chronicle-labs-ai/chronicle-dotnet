using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskMembershipSubjectKind.TaskMembershipSubjectKindSerializer))]
[Serializable]
public readonly record struct TaskMembershipSubjectKind : IStringEnum
{
    public static readonly TaskMembershipSubjectKind Trace = new(Values.Trace);

    public static readonly TaskMembershipSubjectKind Event = new(Values.Event);

    public static readonly TaskMembershipSubjectKind Task = new(Values.Task);

    public TaskMembershipSubjectKind(string value)
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
    public static TaskMembershipSubjectKind FromCustom(string value)
    {
        return new TaskMembershipSubjectKind(value);
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

    public static bool operator ==(TaskMembershipSubjectKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskMembershipSubjectKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskMembershipSubjectKind value) => value.Value;

    public static explicit operator TaskMembershipSubjectKind(string value) => new(value);

    internal class TaskMembershipSubjectKindSerializer : JsonConverter<TaskMembershipSubjectKind>
    {
        public override TaskMembershipSubjectKind Read(
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
            return new TaskMembershipSubjectKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskMembershipSubjectKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskMembershipSubjectKind ReadAsPropertyName(
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
            return new TaskMembershipSubjectKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskMembershipSubjectKind value,
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
