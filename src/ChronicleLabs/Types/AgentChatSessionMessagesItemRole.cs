using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(AgentChatSessionMessagesItemRole.AgentChatSessionMessagesItemRoleSerializer))]
[Serializable]
public readonly record struct AgentChatSessionMessagesItemRole : IStringEnum
{
    public static readonly AgentChatSessionMessagesItemRole User = new(Values.User);

    public static readonly AgentChatSessionMessagesItemRole Agent = new(Values.Agent);

    public AgentChatSessionMessagesItemRole(string value)
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
    public static AgentChatSessionMessagesItemRole FromCustom(string value)
    {
        return new AgentChatSessionMessagesItemRole(value);
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

    public static bool operator ==(AgentChatSessionMessagesItemRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentChatSessionMessagesItemRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentChatSessionMessagesItemRole value) => value.Value;

    public static explicit operator AgentChatSessionMessagesItemRole(string value) => new(value);

    internal class AgentChatSessionMessagesItemRoleSerializer
        : JsonConverter<AgentChatSessionMessagesItemRole>
    {
        public override AgentChatSessionMessagesItemRole Read(
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
            return new AgentChatSessionMessagesItemRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentChatSessionMessagesItemRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentChatSessionMessagesItemRole ReadAsPropertyName(
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
            return new AgentChatSessionMessagesItemRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentChatSessionMessagesItemRole value,
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
        public const string User = "user";

        public const string Agent = "agent";
    }
}
