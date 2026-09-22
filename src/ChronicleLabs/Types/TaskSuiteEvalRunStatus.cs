using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskSuiteEvalRunStatus.TaskSuiteEvalRunStatusSerializer))]
[Serializable]
public readonly record struct TaskSuiteEvalRunStatus : IStringEnum
{
    public static readonly TaskSuiteEvalRunStatus Passing = new(Values.Passing);

    public static readonly TaskSuiteEvalRunStatus Regressed = new(Values.Regressed);

    public static readonly TaskSuiteEvalRunStatus Running = new(Values.Running);

    public static readonly TaskSuiteEvalRunStatus Failed = new(Values.Failed);

    public TaskSuiteEvalRunStatus(string value)
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
    public static TaskSuiteEvalRunStatus FromCustom(string value)
    {
        return new TaskSuiteEvalRunStatus(value);
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

    public static bool operator ==(TaskSuiteEvalRunStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskSuiteEvalRunStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuiteEvalRunStatus value) => value.Value;

    public static explicit operator TaskSuiteEvalRunStatus(string value) => new(value);

    internal class TaskSuiteEvalRunStatusSerializer : JsonConverter<TaskSuiteEvalRunStatus>
    {
        public override TaskSuiteEvalRunStatus Read(
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
            return new TaskSuiteEvalRunStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteEvalRunStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteEvalRunStatus ReadAsPropertyName(
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
            return new TaskSuiteEvalRunStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteEvalRunStatus value,
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
        public const string Passing = "passing";

        public const string Regressed = "regressed";

        public const string Running = "running";

        public const string Failed = "failed";
    }
}
