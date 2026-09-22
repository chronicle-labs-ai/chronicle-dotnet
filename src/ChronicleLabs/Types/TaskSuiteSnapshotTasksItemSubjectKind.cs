using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(TaskSuiteSnapshotTasksItemSubjectKind.TaskSuiteSnapshotTasksItemSubjectKindSerializer)
)]
[Serializable]
public readonly record struct TaskSuiteSnapshotTasksItemSubjectKind : IStringEnum
{
    public static readonly TaskSuiteSnapshotTasksItemSubjectKind Trace = new(Values.Trace);

    public static readonly TaskSuiteSnapshotTasksItemSubjectKind Event = new(Values.Event);

    public static readonly TaskSuiteSnapshotTasksItemSubjectKind Task = new(Values.Task);

    public TaskSuiteSnapshotTasksItemSubjectKind(string value)
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
    public static TaskSuiteSnapshotTasksItemSubjectKind FromCustom(string value)
    {
        return new TaskSuiteSnapshotTasksItemSubjectKind(value);
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

    public static bool operator ==(TaskSuiteSnapshotTasksItemSubjectKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskSuiteSnapshotTasksItemSubjectKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuiteSnapshotTasksItemSubjectKind value) =>
        value.Value;

    public static explicit operator TaskSuiteSnapshotTasksItemSubjectKind(string value) =>
        new(value);

    internal class TaskSuiteSnapshotTasksItemSubjectKindSerializer
        : JsonConverter<TaskSuiteSnapshotTasksItemSubjectKind>
    {
        public override TaskSuiteSnapshotTasksItemSubjectKind Read(
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
            return new TaskSuiteSnapshotTasksItemSubjectKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemSubjectKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteSnapshotTasksItemSubjectKind ReadAsPropertyName(
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
            return new TaskSuiteSnapshotTasksItemSubjectKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemSubjectKind value,
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
