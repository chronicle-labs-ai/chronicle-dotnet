using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateTaskSuiteWithTraceRequestDatasetPurpose.CreateTaskSuiteWithTraceRequestDatasetPurposeSerializer)
)]
[Serializable]
public readonly record struct CreateTaskSuiteWithTraceRequestDatasetPurpose : IStringEnum
{
    public static readonly CreateTaskSuiteWithTraceRequestDatasetPurpose Eval = new(Values.Eval);

    public static readonly CreateTaskSuiteWithTraceRequestDatasetPurpose Training = new(
        Values.Training
    );

    public static readonly CreateTaskSuiteWithTraceRequestDatasetPurpose Replay = new(
        Values.Replay
    );

    public static readonly CreateTaskSuiteWithTraceRequestDatasetPurpose Review = new(
        Values.Review
    );

    public CreateTaskSuiteWithTraceRequestDatasetPurpose(string value)
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
    public static CreateTaskSuiteWithTraceRequestDatasetPurpose FromCustom(string value)
    {
        return new CreateTaskSuiteWithTraceRequestDatasetPurpose(value);
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
        CreateTaskSuiteWithTraceRequestDatasetPurpose value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTaskSuiteWithTraceRequestDatasetPurpose value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateTaskSuiteWithTraceRequestDatasetPurpose value) =>
        value.Value;

    public static explicit operator CreateTaskSuiteWithTraceRequestDatasetPurpose(string value) =>
        new(value);

    internal class CreateTaskSuiteWithTraceRequestDatasetPurposeSerializer
        : JsonConverter<CreateTaskSuiteWithTraceRequestDatasetPurpose>
    {
        public override CreateTaskSuiteWithTraceRequestDatasetPurpose Read(
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
            return new CreateTaskSuiteWithTraceRequestDatasetPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestDatasetPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTaskSuiteWithTraceRequestDatasetPurpose ReadAsPropertyName(
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
            return new CreateTaskSuiteWithTraceRequestDatasetPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestDatasetPurpose value,
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
