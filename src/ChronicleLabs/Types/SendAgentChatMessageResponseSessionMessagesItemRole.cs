using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(SendAgentChatMessageResponseSessionMessagesItemRole.SendAgentChatMessageResponseSessionMessagesItemRoleSerializer)
)]
[Serializable]
public readonly record struct SendAgentChatMessageResponseSessionMessagesItemRole : IStringEnum
{
    public static readonly SendAgentChatMessageResponseSessionMessagesItemRole User = new(
        Values.User
    );

    public static readonly SendAgentChatMessageResponseSessionMessagesItemRole Agent = new(
        Values.Agent
    );

    public SendAgentChatMessageResponseSessionMessagesItemRole(string value)
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
    public static SendAgentChatMessageResponseSessionMessagesItemRole FromCustom(string value)
    {
        return new SendAgentChatMessageResponseSessionMessagesItemRole(value);
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
        SendAgentChatMessageResponseSessionMessagesItemRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SendAgentChatMessageResponseSessionMessagesItemRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        SendAgentChatMessageResponseSessionMessagesItemRole value
    ) => value.Value;

    public static explicit operator SendAgentChatMessageResponseSessionMessagesItemRole(
        string value
    ) => new(value);

    internal class SendAgentChatMessageResponseSessionMessagesItemRoleSerializer
        : JsonConverter<SendAgentChatMessageResponseSessionMessagesItemRole>
    {
        public override SendAgentChatMessageResponseSessionMessagesItemRole Read(
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
            return new SendAgentChatMessageResponseSessionMessagesItemRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SendAgentChatMessageResponseSessionMessagesItemRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SendAgentChatMessageResponseSessionMessagesItemRole ReadAsPropertyName(
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
            return new SendAgentChatMessageResponseSessionMessagesItemRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SendAgentChatMessageResponseSessionMessagesItemRole value,
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
