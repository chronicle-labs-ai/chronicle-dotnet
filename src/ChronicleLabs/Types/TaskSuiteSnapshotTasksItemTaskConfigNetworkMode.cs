using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(TaskSuiteSnapshotTasksItemTaskConfigNetworkMode.TaskSuiteSnapshotTasksItemTaskConfigNetworkModeSerializer)
)]
[Serializable]
public readonly record struct TaskSuiteSnapshotTasksItemTaskConfigNetworkMode : IStringEnum
{
    public static readonly TaskSuiteSnapshotTasksItemTaskConfigNetworkMode Public = new(
        Values.Public
    );

    public static readonly TaskSuiteSnapshotTasksItemTaskConfigNetworkMode NoNetwork = new(
        Values.NoNetwork
    );

    public TaskSuiteSnapshotTasksItemTaskConfigNetworkMode(string value)
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
    public static TaskSuiteSnapshotTasksItemTaskConfigNetworkMode FromCustom(string value)
    {
        return new TaskSuiteSnapshotTasksItemTaskConfigNetworkMode(value);
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
        TaskSuiteSnapshotTasksItemTaskConfigNetworkMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TaskSuiteSnapshotTasksItemTaskConfigNetworkMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuiteSnapshotTasksItemTaskConfigNetworkMode value) =>
        value.Value;

    public static explicit operator TaskSuiteSnapshotTasksItemTaskConfigNetworkMode(string value) =>
        new(value);

    internal class TaskSuiteSnapshotTasksItemTaskConfigNetworkModeSerializer
        : JsonConverter<TaskSuiteSnapshotTasksItemTaskConfigNetworkMode>
    {
        public override TaskSuiteSnapshotTasksItemTaskConfigNetworkMode Read(
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
            return new TaskSuiteSnapshotTasksItemTaskConfigNetworkMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemTaskConfigNetworkMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteSnapshotTasksItemTaskConfigNetworkMode ReadAsPropertyName(
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
            return new TaskSuiteSnapshotTasksItemTaskConfigNetworkMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemTaskConfigNetworkMode value,
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
        public const string Public = "public";

        public const string NoNetwork = "no-network";
    }
}
