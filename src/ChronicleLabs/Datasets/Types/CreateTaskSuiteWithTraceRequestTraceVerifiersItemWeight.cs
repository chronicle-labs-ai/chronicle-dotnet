using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight.CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeightSerializer)
)]
[Serializable]
public readonly record struct CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight : IStringEnum
{
    public static readonly CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight Low = new(
        Values.Low
    );

    public static readonly CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight Med = new(
        Values.Med
    );

    public static readonly CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight High = new(
        Values.High
    );

    public CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight(string value)
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
    public static CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight FromCustom(string value)
    {
        return new CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight(value);
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
        CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight value
    ) => value.Value;

    public static explicit operator CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight(
        string value
    ) => new(value);

    internal class CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeightSerializer
        : JsonConverter<CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight>
    {
        public override CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight Read(
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
            return new CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight ReadAsPropertyName(
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
            return new CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestTraceVerifiersItemWeight value,
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
