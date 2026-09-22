using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TaskVerifiersItemWeight.TaskVerifiersItemWeightSerializer))]
[Serializable]
public readonly record struct TaskVerifiersItemWeight : IStringEnum
{
    public static readonly TaskVerifiersItemWeight Low = new(Values.Low);

    public static readonly TaskVerifiersItemWeight Med = new(Values.Med);

    public static readonly TaskVerifiersItemWeight High = new(Values.High);

    public TaskVerifiersItemWeight(string value)
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
    public static TaskVerifiersItemWeight FromCustom(string value)
    {
        return new TaskVerifiersItemWeight(value);
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

    public static bool operator ==(TaskVerifiersItemWeight value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TaskVerifiersItemWeight value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TaskVerifiersItemWeight value) => value.Value;

    public static explicit operator TaskVerifiersItemWeight(string value) => new(value);

    internal class TaskVerifiersItemWeightSerializer : JsonConverter<TaskVerifiersItemWeight>
    {
        public override TaskVerifiersItemWeight Read(
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
            return new TaskVerifiersItemWeight(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaskVerifiersItemWeight value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TaskVerifiersItemWeight ReadAsPropertyName(
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
            return new TaskVerifiersItemWeight(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TaskVerifiersItemWeight value,
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
        public const string Low = "low";

        public const string Med = "med";

        public const string High = "high";
    }
}
