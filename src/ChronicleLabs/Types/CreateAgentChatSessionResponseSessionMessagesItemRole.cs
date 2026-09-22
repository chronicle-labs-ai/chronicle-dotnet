using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateAgentChatSessionResponseSessionMessagesItemRole.CreateAgentChatSessionResponseSessionMessagesItemRoleSerializer)
)]
[Serializable]
public readonly record struct CreateAgentChatSessionResponseSessionMessagesItemRole : IStringEnum
{
    public static readonly CreateAgentChatSessionResponseSessionMessagesItemRole User = new(
        Values.User
    );

    public static readonly CreateAgentChatSessionResponseSessionMessagesItemRole Agent = new(
        Values.Agent
    );

    public CreateAgentChatSessionResponseSessionMessagesItemRole(string value)
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
    public static CreateAgentChatSessionResponseSessionMessagesItemRole FromCustom(string value)
    {
        return new CreateAgentChatSessionResponseSessionMessagesItemRole(value);
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
        CreateAgentChatSessionResponseSessionMessagesItemRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateAgentChatSessionResponseSessionMessagesItemRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateAgentChatSessionResponseSessionMessagesItemRole value
    ) => value.Value;

    public static explicit operator CreateAgentChatSessionResponseSessionMessagesItemRole(
        string value
    ) => new(value);

    internal class CreateAgentChatSessionResponseSessionMessagesItemRoleSerializer
        : JsonConverter<CreateAgentChatSessionResponseSessionMessagesItemRole>
    {
        public override CreateAgentChatSessionResponseSessionMessagesItemRole Read(
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
            return new CreateAgentChatSessionResponseSessionMessagesItemRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateAgentChatSessionResponseSessionMessagesItemRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateAgentChatSessionResponseSessionMessagesItemRole ReadAsPropertyName(
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
            return new CreateAgentChatSessionResponseSessionMessagesItemRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateAgentChatSessionResponseSessionMessagesItemRole value,
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
