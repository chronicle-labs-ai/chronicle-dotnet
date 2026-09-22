using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskMembershipSplit.TaskMembershipSplitSerializer))]
[Serializable]
public readonly record struct TaskMembershipSplit : IStringEnum
{
    public static readonly TaskMembershipSplit Train = new(Values.Train);

    public static readonly TaskMembershipSplit Validation = new(Values.Validation);

    public static readonly TaskMembershipSplit Test = new(Values.Test);

    public TaskMembershipSplit(string value)
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
    public static TaskMembershipSplit FromCustom(string value)
    {
        return new TaskMembershipSplit(value);
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

    public static bool operator ==(TaskMembershipSplit value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskMembershipSplit value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskMembershipSplit value) => value.Value;

    public static explicit operator TaskMembershipSplit(string value) => new(value);

    internal class TaskMembershipSplitSerializer : JsonConverter<TaskMembershipSplit>
    {
        public override TaskMembershipSplit Read(
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
            return new TaskMembershipSplit(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskMembershipSplit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskMembershipSplit ReadAsPropertyName(
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
            return new TaskMembershipSplit(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskMembershipSplit value,
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
        public const string Train = "train";

        public const string Validation = "validation";

        public const string Test = "test";
    }
}
