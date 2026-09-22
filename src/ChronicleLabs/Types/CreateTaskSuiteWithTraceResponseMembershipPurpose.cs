using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateTaskSuiteWithTraceResponseMembershipPurpose.CreateTaskSuiteWithTraceResponseMembershipPurposeSerializer)
)]
[Serializable]
public readonly record struct CreateTaskSuiteWithTraceResponseMembershipPurpose : IStringEnum
{
    public static readonly CreateTaskSuiteWithTraceResponseMembershipPurpose Eval = new(
        Values.Eval
    );

    public static readonly CreateTaskSuiteWithTraceResponseMembershipPurpose Training = new(
        Values.Training
    );

    public static readonly CreateTaskSuiteWithTraceResponseMembershipPurpose Replay = new(
        Values.Replay
    );

    public static readonly CreateTaskSuiteWithTraceResponseMembershipPurpose Review = new(
        Values.Review
    );

    public CreateTaskSuiteWithTraceResponseMembershipPurpose(string value)
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
    public static CreateTaskSuiteWithTraceResponseMembershipPurpose FromCustom(string value)
    {
        return new CreateTaskSuiteWithTraceResponseMembershipPurpose(value);
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
        CreateTaskSuiteWithTraceResponseMembershipPurpose value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTaskSuiteWithTraceResponseMembershipPurpose value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTaskSuiteWithTraceResponseMembershipPurpose value
    ) => value.Value;

    public static explicit operator CreateTaskSuiteWithTraceResponseMembershipPurpose(
        string value
    ) => new(value);

    internal class CreateTaskSuiteWithTraceResponseMembershipPurposeSerializer
        : JsonConverter<CreateTaskSuiteWithTraceResponseMembershipPurpose>
    {
        public override CreateTaskSuiteWithTraceResponseMembershipPurpose Read(
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
            return new CreateTaskSuiteWithTraceResponseMembershipPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceResponseMembershipPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTaskSuiteWithTraceResponseMembershipPurpose ReadAsPropertyName(
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
            return new CreateTaskSuiteWithTraceResponseMembershipPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceResponseMembershipPurpose value,
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
