using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskSuiteSnapshotDatasetPurpose.TaskSuiteSnapshotDatasetPurposeSerializer))]
[Serializable]
public readonly record struct TaskSuiteSnapshotDatasetPurpose : IStringEnum
{
    public static readonly TaskSuiteSnapshotDatasetPurpose Eval = new(Values.Eval);

    public static readonly TaskSuiteSnapshotDatasetPurpose Training = new(Values.Training);

    public static readonly TaskSuiteSnapshotDatasetPurpose Replay = new(Values.Replay);

    public static readonly TaskSuiteSnapshotDatasetPurpose Review = new(Values.Review);

    public TaskSuiteSnapshotDatasetPurpose(string value)
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
    public static TaskSuiteSnapshotDatasetPurpose FromCustom(string value)
    {
        return new TaskSuiteSnapshotDatasetPurpose(value);
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

    public static bool operator ==(TaskSuiteSnapshotDatasetPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskSuiteSnapshotDatasetPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuiteSnapshotDatasetPurpose value) => value.Value;

    public static explicit operator TaskSuiteSnapshotDatasetPurpose(string value) => new(value);

    internal class TaskSuiteSnapshotDatasetPurposeSerializer
        : JsonConverter<TaskSuiteSnapshotDatasetPurpose>
    {
        public override TaskSuiteSnapshotDatasetPurpose Read(
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
            return new TaskSuiteSnapshotDatasetPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotDatasetPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteSnapshotDatasetPurpose ReadAsPropertyName(
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
            return new TaskSuiteSnapshotDatasetPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteSnapshotDatasetPurpose value,
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
