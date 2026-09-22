using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AddTaskFromTraceResponseMembershipPurpose.AddTaskFromTraceResponseMembershipPurposeSerializer)
)]
[Serializable]
public readonly record struct AddTaskFromTraceResponseMembershipPurpose : IStringEnum
{
    public static readonly AddTaskFromTraceResponseMembershipPurpose Eval = new(Values.Eval);

    public static readonly AddTaskFromTraceResponseMembershipPurpose Training = new(
        Values.Training
    );

    public static readonly AddTaskFromTraceResponseMembershipPurpose Replay = new(Values.Replay);

    public static readonly AddTaskFromTraceResponseMembershipPurpose Review = new(Values.Review);

    public AddTaskFromTraceResponseMembershipPurpose(string value)
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
    public static AddTaskFromTraceResponseMembershipPurpose FromCustom(string value)
    {
        return new AddTaskFromTraceResponseMembershipPurpose(value);
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
        AddTaskFromTraceResponseMembershipPurpose value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AddTaskFromTraceResponseMembershipPurpose value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AddTaskFromTraceResponseMembershipPurpose value) =>
        value.Value;

    public static explicit operator AddTaskFromTraceResponseMembershipPurpose(string value) =>
        new(value);

    internal class AddTaskFromTraceResponseMembershipPurposeSerializer
        : JsonConverter<AddTaskFromTraceResponseMembershipPurpose>
    {
        public override AddTaskFromTraceResponseMembershipPurpose Read(
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
            return new AddTaskFromTraceResponseMembershipPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseMembershipPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AddTaskFromTraceResponseMembershipPurpose ReadAsPropertyName(
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
            return new AddTaskFromTraceResponseMembershipPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AddTaskFromTraceResponseMembershipPurpose value,
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
