using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentSnapshotRunsItemToolCallsItemStatus.AgentSnapshotRunsItemToolCallsItemStatusSerializer)
)]
[Serializable]
public readonly record struct AgentSnapshotRunsItemToolCallsItemStatus : IStringEnum
{
    public static readonly AgentSnapshotRunsItemToolCallsItemStatus Started = new(Values.Started);

    public static readonly AgentSnapshotRunsItemToolCallsItemStatus Success = new(Values.Success);

    public static readonly AgentSnapshotRunsItemToolCallsItemStatus Error = new(Values.Error);

    public AgentSnapshotRunsItemToolCallsItemStatus(string value)
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
    public static AgentSnapshotRunsItemToolCallsItemStatus FromCustom(string value)
    {
        return new AgentSnapshotRunsItemToolCallsItemStatus(value);
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
        AgentSnapshotRunsItemToolCallsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentSnapshotRunsItemToolCallsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AgentSnapshotRunsItemToolCallsItemStatus value) =>
        value.Value;

    public static explicit operator AgentSnapshotRunsItemToolCallsItemStatus(string value) =>
        new(value);

    internal class AgentSnapshotRunsItemToolCallsItemStatusSerializer
        : JsonConverter<AgentSnapshotRunsItemToolCallsItemStatus>
    {
        public override AgentSnapshotRunsItemToolCallsItemStatus Read(
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
            return new AgentSnapshotRunsItemToolCallsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotRunsItemToolCallsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotRunsItemToolCallsItemStatus ReadAsPropertyName(
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
            return new AgentSnapshotRunsItemToolCallsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotRunsItemToolCallsItemStatus value,
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
