using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateTaskSuiteWithTraceRequestTraceSplit.CreateTaskSuiteWithTraceRequestTraceSplitSerializer)
)]
[Serializable]
public readonly record struct CreateTaskSuiteWithTraceRequestTraceSplit : IStringEnum
{
    public static readonly CreateTaskSuiteWithTraceRequestTraceSplit Train = new(Values.Train);

    public static readonly CreateTaskSuiteWithTraceRequestTraceSplit Validation = new(
        Values.Validation
    );

    public static readonly CreateTaskSuiteWithTraceRequestTraceSplit Test = new(Values.Test);

    public CreateTaskSuiteWithTraceRequestTraceSplit(string value)
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
    public static CreateTaskSuiteWithTraceRequestTraceSplit FromCustom(string value)
    {
        return new CreateTaskSuiteWithTraceRequestTraceSplit(value);
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
        CreateTaskSuiteWithTraceRequestTraceSplit value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTaskSuiteWithTraceRequestTraceSplit value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateTaskSuiteWithTraceRequestTraceSplit value) =>
        value.Value;

    public static explicit operator CreateTaskSuiteWithTraceRequestTraceSplit(string value) =>
        new(value);

    internal class CreateTaskSuiteWithTraceRequestTraceSplitSerializer
        : JsonConverter<CreateTaskSuiteWithTraceRequestTraceSplit>
    {
        public override CreateTaskSuiteWithTraceRequestTraceSplit Read(
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
            return new CreateTaskSuiteWithTraceRequestTraceSplit(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestTraceSplit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTaskSuiteWithTraceRequestTraceSplit ReadAsPropertyName(
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
            return new CreateTaskSuiteWithTraceRequestTraceSplit(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestTraceSplit value,
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
