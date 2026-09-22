using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(RecordAgentRunsRequestRunsItemOperation.RecordAgentRunsRequestRunsItemOperationSerializer)
)]
[Serializable]
public readonly record struct RecordAgentRunsRequestRunsItemOperation : IStringEnum
{
    public static readonly RecordAgentRunsRequestRunsItemOperation Generate = new(Values.Generate);

    public static readonly RecordAgentRunsRequestRunsItemOperation Stream = new(Values.Stream);

    public RecordAgentRunsRequestRunsItemOperation(string value)
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
    public static RecordAgentRunsRequestRunsItemOperation FromCustom(string value)
    {
        return new RecordAgentRunsRequestRunsItemOperation(value);
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

    public static bool operator ==(RecordAgentRunsRequestRunsItemOperation value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RecordAgentRunsRequestRunsItemOperation value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RecordAgentRunsRequestRunsItemOperation value) =>
        value.Value;

    public static explicit operator RecordAgentRunsRequestRunsItemOperation(string value) =>
        new(value);

    internal class RecordAgentRunsRequestRunsItemOperationSerializer
        : JsonConverter<RecordAgentRunsRequestRunsItemOperation>
    {
        public override RecordAgentRunsRequestRunsItemOperation Read(
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
            return new RecordAgentRunsRequestRunsItemOperation(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RecordAgentRunsRequestRunsItemOperation value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RecordAgentRunsRequestRunsItemOperation ReadAsPropertyName(
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
            return new RecordAgentRunsRequestRunsItemOperation(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RecordAgentRunsRequestRunsItemOperation value,
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
        public const string Generate = "generate";

        public const string Stream = "stream";
    }
}
