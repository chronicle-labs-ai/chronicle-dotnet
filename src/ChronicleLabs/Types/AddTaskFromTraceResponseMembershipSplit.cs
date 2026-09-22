using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AddTaskFromTraceResponseMembershipSplit.AddTaskFromTraceResponseMembershipSplitSerializer)
)]
[Serializable]
public readonly record struct AddTaskFromTraceResponseMembershipSplit : IStringEnum
{
    public static readonly AddTaskFromTraceResponseMembershipSplit Train = new(Values.Train);

    public static readonly AddTaskFromTraceResponseMembershipSplit Validation = new(
        Values.Validation
    );

    public static readonly AddTaskFromTraceResponseMembershipSplit Test = new(Values.Test);

    public AddTaskFromTraceResponseMembershipSplit(string value)
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
    public static AddTaskFromTraceResponseMembershipSplit FromCustom(string value)
    {
        return new AddTaskFromTraceResponseMembershipSplit(value);
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

    public static bool operator ==(AddTaskFromTraceResponseMembershipSplit value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AddTaskFromTraceResponseMembershipSplit value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AddTaskFromTraceResponseMembershipSplit value) =>
        value.Value;

    public static explicit operator AddTaskFromTraceResponseMembershipSplit(string value) =>
        new(value);

    internal class AddTaskFromTraceResponseMembershipSplitSerializer
        : JsonConverter<AddTaskFromTraceResponseMembershipSplit>
    {
        public override AddTaskFromTraceResponseMembershipSplit Read(
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
            return new AddTaskFromTraceResponseMembershipSplit(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseMembershipSplit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddTaskFromTraceResponseMembershipSplit ReadAsPropertyName(
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
            return new AddTaskFromTraceResponseMembershipSplit(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseMembershipSplit value,
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
