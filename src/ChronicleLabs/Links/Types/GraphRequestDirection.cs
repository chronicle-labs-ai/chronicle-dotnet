using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(GraphRequestDirection.GraphRequestDirectionSerializer))]
[Serializable]
public readonly record struct GraphRequestDirection : IStringEnum
{
    public static readonly GraphRequestDirection Outgoing = new(Values.Outgoing);

    public static readonly GraphRequestDirection Incoming = new(Values.Incoming);

    public static readonly GraphRequestDirection Both = new(Values.Both);

    public GraphRequestDirection(string value)
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
    public static GraphRequestDirection FromCustom(string value)
    {
        return new GraphRequestDirection(value);
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

    public static bool operator ==(GraphRequestDirection value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GraphRequestDirection value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GraphRequestDirection value) => value.Value;

    public static explicit operator GraphRequestDirection(string value) => new(value);

    internal class GraphRequestDirectionSerializer : JsonConverter<GraphRequestDirection>
    {
        public override GraphRequestDirection Read(
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
            return new GraphRequestDirection(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GraphRequestDirection value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GraphRequestDirection ReadAsPropertyName(
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
            return new GraphRequestDirection(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GraphRequestDirection value,
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
        public const string Outgoing = "outgoing";

        public const string Incoming = "incoming";

        public const string Both = "both";
    }
}
