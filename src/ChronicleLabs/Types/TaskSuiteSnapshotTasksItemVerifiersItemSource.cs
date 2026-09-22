using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(TaskSuiteSnapshotTasksItemVerifiersItemSource.TaskSuiteSnapshotTasksItemVerifiersItemSourceSerializer)
)]
[Serializable]
public readonly record struct TaskSuiteSnapshotTasksItemVerifiersItemSource : IStringEnum
{
    public static readonly TaskSuiteSnapshotTasksItemVerifiersItemSource Proposed = new(
        Values.Proposed
    );

    public static readonly TaskSuiteSnapshotTasksItemVerifiersItemSource Library = new(
        Values.Library
    );

    public static readonly TaskSuiteSnapshotTasksItemVerifiersItemSource Custom = new(
        Values.Custom
    );

    public static readonly TaskSuiteSnapshotTasksItemVerifiersItemSource Dataset = new(
        Values.Dataset
    );

    public TaskSuiteSnapshotTasksItemVerifiersItemSource(string value)
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
    public static TaskSuiteSnapshotTasksItemVerifiersItemSource FromCustom(string value)
    {
        return new TaskSuiteSnapshotTasksItemVerifiersItemSource(value);
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

    public static bool operator ==(
        TaskSuiteSnapshotTasksItemVerifiersItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TaskSuiteSnapshotTasksItemVerifiersItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuiteSnapshotTasksItemVerifiersItemSource value) =>
        value.Value;

    public static explicit operator TaskSuiteSnapshotTasksItemVerifiersItemSource(string value) =>
        new(value);

    internal class TaskSuiteSnapshotTasksItemVerifiersItemSourceSerializer
        : JsonConverter<TaskSuiteSnapshotTasksItemVerifiersItemSource>
    {
        public override TaskSuiteSnapshotTasksItemVerifiersItemSource Read(
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
            return new TaskSuiteSnapshotTasksItemVerifiersItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemVerifiersItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteSnapshotTasksItemVerifiersItemSource ReadAsPropertyName(
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
            return new TaskSuiteSnapshotTasksItemVerifiersItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemVerifiersItemSource value,
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
        public const string Proposed = "proposed";

        public const string Library = "library";

        public const string Custom = "custom";

        public const string Dataset = "dataset";
    }
}
