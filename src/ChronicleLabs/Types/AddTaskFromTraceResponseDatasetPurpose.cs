using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AddTaskFromTraceResponseDatasetPurpose.AddTaskFromTraceResponseDatasetPurposeSerializer)
)]
[Serializable]
public readonly record struct AddTaskFromTraceResponseDatasetPurpose : IStringEnum
{
    public static readonly AddTaskFromTraceResponseDatasetPurpose Eval = new(Values.Eval);

    public static readonly AddTaskFromTraceResponseDatasetPurpose Training = new(Values.Training);

    public static readonly AddTaskFromTraceResponseDatasetPurpose Replay = new(Values.Replay);

    public static readonly AddTaskFromTraceResponseDatasetPurpose Review = new(Values.Review);

    public AddTaskFromTraceResponseDatasetPurpose(string value)
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
    public static AddTaskFromTraceResponseDatasetPurpose FromCustom(string value)
    {
        return new AddTaskFromTraceResponseDatasetPurpose(value);
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

    public static bool operator ==(AddTaskFromTraceResponseDatasetPurpose value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AddTaskFromTraceResponseDatasetPurpose value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AddTaskFromTraceResponseDatasetPurpose value) =>
        value.Value;

    public static explicit operator AddTaskFromTraceResponseDatasetPurpose(string value) =>
        new(value);

    internal class AddTaskFromTraceResponseDatasetPurposeSerializer
        : JsonConverter<AddTaskFromTraceResponseDatasetPurpose>
    {
        public override AddTaskFromTraceResponseDatasetPurpose Read(
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
            return new AddTaskFromTraceResponseDatasetPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseDatasetPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddTaskFromTraceResponseDatasetPurpose ReadAsPropertyName(
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
            return new AddTaskFromTraceResponseDatasetPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseDatasetPurpose value,
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
