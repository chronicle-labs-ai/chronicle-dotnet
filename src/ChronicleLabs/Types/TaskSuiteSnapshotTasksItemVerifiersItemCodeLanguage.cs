using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage.TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguageSerializer)
)]
[Serializable]
public readonly record struct TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage : IStringEnum
{
    public static readonly TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage Python = new(
        Values.Python
    );

    public static readonly TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage Typescript = new(
        Values.Typescript
    );

    public TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage(string value)
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
    public static TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage FromCustom(string value)
    {
        return new TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage(value);
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
        TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage value
    ) => value.Value;

    public static explicit operator TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage(
        string value
    ) => new(value);

    internal class TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguageSerializer
        : JsonConverter<TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage>
    {
        public override TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage Read(
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
            return new TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage ReadAsPropertyName(
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
            return new TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotTasksItemVerifiersItemCodeLanguage value,
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
        public const string Python = "python";

        public const string Typescript = "typescript";
    }
}
