using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(RecordAgentRunsRequestRunsItemToolCallsItemStatus.RecordAgentRunsRequestRunsItemToolCallsItemStatusSerializer)
)]
[Serializable]
public readonly record struct RecordAgentRunsRequestRunsItemToolCallsItemStatus : IStringEnum
{
    public static readonly RecordAgentRunsRequestRunsItemToolCallsItemStatus Started = new(
        Values.Started
    );

    public static readonly RecordAgentRunsRequestRunsItemToolCallsItemStatus Success = new(
        Values.Success
    );

    public static readonly RecordAgentRunsRequestRunsItemToolCallsItemStatus Error = new(
        Values.Error
    );

    public RecordAgentRunsRequestRunsItemToolCallsItemStatus(string value)
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
    public static RecordAgentRunsRequestRunsItemToolCallsItemStatus FromCustom(string value)
    {
        return new RecordAgentRunsRequestRunsItemToolCallsItemStatus(value);
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
        RecordAgentRunsRequestRunsItemToolCallsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RecordAgentRunsRequestRunsItemToolCallsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RecordAgentRunsRequestRunsItemToolCallsItemStatus value
    ) => value.Value;

    public static explicit operator RecordAgentRunsRequestRunsItemToolCallsItemStatus(
        string value
    ) => new(value);

    internal class RecordAgentRunsRequestRunsItemToolCallsItemStatusSerializer
        : JsonConverter<RecordAgentRunsRequestRunsItemToolCallsItemStatus>
    {
        public override RecordAgentRunsRequestRunsItemToolCallsItemStatus Read(
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
            return new RecordAgentRunsRequestRunsItemToolCallsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RecordAgentRunsRequestRunsItemToolCallsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RecordAgentRunsRequestRunsItemToolCallsItemStatus ReadAsPropertyName(
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
            return new RecordAgentRunsRequestRunsItemToolCallsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RecordAgentRunsRequestRunsItemToolCallsItemStatus value,
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
