using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AddTaskFromTraceResponseMembershipSubjectKind.AddTaskFromTraceResponseMembershipSubjectKindSerializer)
)]
[Serializable]
public readonly record struct AddTaskFromTraceResponseMembershipSubjectKind : IStringEnum
{
    public static readonly AddTaskFromTraceResponseMembershipSubjectKind Trace = new(Values.Trace);

    public static readonly AddTaskFromTraceResponseMembershipSubjectKind Event = new(Values.Event);

    public static readonly AddTaskFromTraceResponseMembershipSubjectKind Task = new(Values.Task);

    public AddTaskFromTraceResponseMembershipSubjectKind(string value)
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
    public static AddTaskFromTraceResponseMembershipSubjectKind FromCustom(string value)
    {
        return new AddTaskFromTraceResponseMembershipSubjectKind(value);
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
        AddTaskFromTraceResponseMembershipSubjectKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddTaskFromTraceResponseMembershipSubjectKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AddTaskFromTraceResponseMembershipSubjectKind value) =>
        value.Value;

    public static explicit operator AddTaskFromTraceResponseMembershipSubjectKind(string value) =>
        new(value);

    internal class AddTaskFromTraceResponseMembershipSubjectKindSerializer
        : JsonConverter<AddTaskFromTraceResponseMembershipSubjectKind>
    {
        public override AddTaskFromTraceResponseMembershipSubjectKind Read(
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
            return new AddTaskFromTraceResponseMembershipSubjectKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseMembershipSubjectKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddTaskFromTraceResponseMembershipSubjectKind ReadAsPropertyName(
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
            return new AddTaskFromTraceResponseMembershipSubjectKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseMembershipSubjectKind value,
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
        public const string Trace = "trace";

        public const string Event = "event";

        public const string Task = "task";
    }
}
