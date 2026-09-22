using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(CreateTaskSuitePayloadPurpose.CreateTaskSuitePayloadPurposeSerializer))]
[Serializable]
public readonly record struct CreateTaskSuitePayloadPurpose : IStringEnum
{
    public static readonly CreateTaskSuitePayloadPurpose Eval = new(Values.Eval);

    public static readonly CreateTaskSuitePayloadPurpose Training = new(Values.Training);

    public static readonly CreateTaskSuitePayloadPurpose Replay = new(Values.Replay);

    public static readonly CreateTaskSuitePayloadPurpose Review = new(Values.Review);

    public CreateTaskSuitePayloadPurpose(string value)
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
    public static CreateTaskSuitePayloadPurpose FromCustom(string value)
    {
        return new CreateTaskSuitePayloadPurpose(value);
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

    public static bool operator ==(CreateTaskSuitePayloadPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTaskSuitePayloadPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTaskSuitePayloadPurpose value) => value.Value;

    public static explicit operator CreateTaskSuitePayloadPurpose(string value) => new(value);

    internal class CreateTaskSuitePayloadPurposeSerializer
        : JsonConverter<CreateTaskSuitePayloadPurpose>
    {
        public override CreateTaskSuitePayloadPurpose Read(
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
            return new CreateTaskSuitePayloadPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTaskSuitePayloadPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTaskSuitePayloadPurpose ReadAsPropertyName(
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
            return new CreateTaskSuitePayloadPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTaskSuitePayloadPurpose value,
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
