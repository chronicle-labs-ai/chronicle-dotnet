using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskSuiteDetailDatasetPurpose.TaskSuiteDetailDatasetPurposeSerializer))]
[Serializable]
public readonly record struct TaskSuiteDetailDatasetPurpose : IStringEnum
{
    public static readonly TaskSuiteDetailDatasetPurpose Eval = new(Values.Eval);

    public static readonly TaskSuiteDetailDatasetPurpose Training = new(Values.Training);

    public static readonly TaskSuiteDetailDatasetPurpose Replay = new(Values.Replay);

    public static readonly TaskSuiteDetailDatasetPurpose Review = new(Values.Review);

    public TaskSuiteDetailDatasetPurpose(string value)
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
    public static TaskSuiteDetailDatasetPurpose FromCustom(string value)
    {
        return new TaskSuiteDetailDatasetPurpose(value);
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

    public static bool operator ==(TaskSuiteDetailDatasetPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskSuiteDetailDatasetPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskSuiteDetailDatasetPurpose value) => value.Value;

    public static explicit operator TaskSuiteDetailDatasetPurpose(string value) => new(value);

    internal class TaskSuiteDetailDatasetPurposeSerializer
        : JsonConverter<TaskSuiteDetailDatasetPurpose>
    {
        public override TaskSuiteDetailDatasetPurpose Read(
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
            return new TaskSuiteDetailDatasetPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskSuiteDetailDatasetPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskSuiteDetailDatasetPurpose ReadAsPropertyName(
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
            return new TaskSuiteDetailDatasetPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskSuiteDetailDatasetPurpose value,
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
