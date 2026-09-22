using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(RecordAgentRunsRequestRunsItemStatus.RecordAgentRunsRequestRunsItemStatusSerializer)
)]
[Serializable]
public readonly record struct RecordAgentRunsRequestRunsItemStatus : IStringEnum
{
    public static readonly RecordAgentRunsRequestRunsItemStatus Started = new(Values.Started);

    public static readonly RecordAgentRunsRequestRunsItemStatus Success = new(Values.Success);

    public static readonly RecordAgentRunsRequestRunsItemStatus Error = new(Values.Error);

    public RecordAgentRunsRequestRunsItemStatus(string value)
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
    public static RecordAgentRunsRequestRunsItemStatus FromCustom(string value)
    {
        return new RecordAgentRunsRequestRunsItemStatus(value);
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

    public static bool operator ==(RecordAgentRunsRequestRunsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RecordAgentRunsRequestRunsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RecordAgentRunsRequestRunsItemStatus value) =>
        value.Value;

    public static explicit operator RecordAgentRunsRequestRunsItemStatus(string value) =>
        new(value);

    internal class RecordAgentRunsRequestRunsItemStatusSerializer
        : JsonConverter<RecordAgentRunsRequestRunsItemStatus>
    {
        public override RecordAgentRunsRequestRunsItemStatus Read(
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
            return new RecordAgentRunsRequestRunsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RecordAgentRunsRequestRunsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RecordAgentRunsRequestRunsItemStatus ReadAsPropertyName(
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
            return new RecordAgentRunsRequestRunsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RecordAgentRunsRequestRunsItemStatus value,
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
        public const string Started = "started";

        public const string Success = "success";

        public const string Error = "error";
    }
}
