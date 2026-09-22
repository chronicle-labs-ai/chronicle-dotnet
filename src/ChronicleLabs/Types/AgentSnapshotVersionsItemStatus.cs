using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(AgentSnapshotVersionsItemStatus.AgentSnapshotVersionsItemStatusSerializer))]
[Serializable]
public readonly record struct AgentSnapshotVersionsItemStatus : IStringEnum
{
    public static readonly AgentSnapshotVersionsItemStatus Current = new(Values.Current);

    public static readonly AgentSnapshotVersionsItemStatus Stable = new(Values.Stable);

    public static readonly AgentSnapshotVersionsItemStatus Deprecated = new(Values.Deprecated);

    public static readonly AgentSnapshotVersionsItemStatus Draft = new(Values.Draft);

    public AgentSnapshotVersionsItemStatus(string value)
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
    public static AgentSnapshotVersionsItemStatus FromCustom(string value)
    {
        return new AgentSnapshotVersionsItemStatus(value);
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

    public static bool operator ==(AgentSnapshotVersionsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentSnapshotVersionsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentSnapshotVersionsItemStatus value) => value.Value;

    public static explicit operator AgentSnapshotVersionsItemStatus(string value) => new(value);

    internal class AgentSnapshotVersionsItemStatusSerializer
        : JsonConverter<AgentSnapshotVersionsItemStatus>
    {
        public override AgentSnapshotVersionsItemStatus Read(
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
            return new AgentSnapshotVersionsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotVersionsItemStatus ReadAsPropertyName(
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
            return new AgentSnapshotVersionsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemStatus value,
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
        public const string Current = "current";

        public const string Stable = "stable";

        public const string Deprecated = "deprecated";

        public const string Draft = "draft";
    }
}
