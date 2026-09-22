using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AddTaskFromTraceRequestVerifiersItemWeight.AddTaskFromTraceRequestVerifiersItemWeightSerializer)
)]
[Serializable]
public readonly record struct AddTaskFromTraceRequestVerifiersItemWeight : IStringEnum
{
    public static readonly AddTaskFromTraceRequestVerifiersItemWeight Low = new(Values.Low);

    public static readonly AddTaskFromTraceRequestVerifiersItemWeight Med = new(Values.Med);

    public static readonly AddTaskFromTraceRequestVerifiersItemWeight High = new(Values.High);

    public AddTaskFromTraceRequestVerifiersItemWeight(string value)
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
    public static AddTaskFromTraceRequestVerifiersItemWeight FromCustom(string value)
    {
        return new AddTaskFromTraceRequestVerifiersItemWeight(value);
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
        AddTaskFromTraceRequestVerifiersItemWeight value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddTaskFromTraceRequestVerifiersItemWeight value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AddTaskFromTraceRequestVerifiersItemWeight value) =>
        value.Value;

    public static explicit operator AddTaskFromTraceRequestVerifiersItemWeight(string value) =>
        new(value);

    internal class AddTaskFromTraceRequestVerifiersItemWeightSerializer
        : JsonConverter<AddTaskFromTraceRequestVerifiersItemWeight>
    {
        public override AddTaskFromTraceRequestVerifiersItemWeight Read(
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
            return new AddTaskFromTraceRequestVerifiersItemWeight(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddTaskFromTraceRequestVerifiersItemWeight value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddTaskFromTraceRequestVerifiersItemWeight ReadAsPropertyName(
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
            return new AddTaskFromTraceRequestVerifiersItemWeight(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddTaskFromTraceRequestVerifiersItemWeight value,
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
