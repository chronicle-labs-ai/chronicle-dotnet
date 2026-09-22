using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskMembershipPurpose.TaskMembershipPurposeSerializer))]
[Serializable]
public readonly record struct TaskMembershipPurpose : IStringEnum
{
    public static readonly TaskMembershipPurpose Eval = new(Values.Eval);

    public static readonly TaskMembershipPurpose Training = new(Values.Training);

    public static readonly TaskMembershipPurpose Replay = new(Values.Replay);

    public static readonly TaskMembershipPurpose Review = new(Values.Review);

    public TaskMembershipPurpose(string value)
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
    public static TaskMembershipPurpose FromCustom(string value)
    {
        return new TaskMembershipPurpose(value);
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

    public static bool operator ==(TaskMembershipPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskMembershipPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskMembershipPurpose value) => value.Value;

    public static explicit operator TaskMembershipPurpose(string value) => new(value);

    internal class TaskMembershipPurposeSerializer : JsonConverter<TaskMembershipPurpose>
    {
        public override TaskMembershipPurpose Read(
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
            return new TaskMembershipPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskMembershipPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskMembershipPurpose ReadAsPropertyName(
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
            return new TaskMembershipPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskMembershipPurpose value,
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
