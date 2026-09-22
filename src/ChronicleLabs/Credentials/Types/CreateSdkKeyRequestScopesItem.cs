using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(CreateSdkKeyRequestScopesItem.CreateSdkKeyRequestScopesItemSerializer))]
[Serializable]
public readonly record struct CreateSdkKeyRequestScopesItem : IStringEnum
{
    public static readonly CreateSdkKeyRequestScopesItem TracesWrite = new(Values.TracesWrite);

    public static readonly CreateSdkKeyRequestScopesItem EventsRead = new(Values.EventsRead);

    public static readonly CreateSdkKeyRequestScopesItem EventsWrite = new(Values.EventsWrite);

    public static readonly CreateSdkKeyRequestScopesItem UsersWrite = new(Values.UsersWrite);

    public static readonly CreateSdkKeyRequestScopesItem SignalsWrite = new(Values.SignalsWrite);

    public static readonly CreateSdkKeyRequestScopesItem AgentsWrite = new(Values.AgentsWrite);

    public CreateSdkKeyRequestScopesItem(string value)
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
    public static CreateSdkKeyRequestScopesItem FromCustom(string value)
    {
        return new CreateSdkKeyRequestScopesItem(value);
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

    public static bool operator ==(CreateSdkKeyRequestScopesItem value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSdkKeyRequestScopesItem value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSdkKeyRequestScopesItem value) => value.Value;

    public static explicit operator CreateSdkKeyRequestScopesItem(string value) => new(value);

    internal class CreateSdkKeyRequestScopesItemSerializer
        : JsonConverter<CreateSdkKeyRequestScopesItem>
    {
        public override CreateSdkKeyRequestScopesItem Read(
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
            return new CreateSdkKeyRequestScopesItem(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSdkKeyRequestScopesItem value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSdkKeyRequestScopesItem ReadAsPropertyName(
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
            return new CreateSdkKeyRequestScopesItem(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSdkKeyRequestScopesItem value,
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
        public const string TracesWrite = "traces:write";

        public const string EventsRead = "events:read";

        public const string EventsWrite = "events:write";

        public const string UsersWrite = "users:write";

        public const string SignalsWrite = "signals:write";

        public const string AgentsWrite = "agents:write";
    }
}
