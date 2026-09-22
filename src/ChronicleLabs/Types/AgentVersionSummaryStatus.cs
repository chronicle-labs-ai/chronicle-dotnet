using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(AgentVersionSummaryStatus.AgentVersionSummaryStatusSerializer))]
[Serializable]
public readonly record struct AgentVersionSummaryStatus : IStringEnum
{
    public static readonly AgentVersionSummaryStatus Current = new(Values.Current);

    public static readonly AgentVersionSummaryStatus Stable = new(Values.Stable);

    public static readonly AgentVersionSummaryStatus Deprecated = new(Values.Deprecated);

    public static readonly AgentVersionSummaryStatus Draft = new(Values.Draft);

    public AgentVersionSummaryStatus(string value)
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
    public static AgentVersionSummaryStatus FromCustom(string value)
    {
        return new AgentVersionSummaryStatus(value);
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

    public static bool operator ==(AgentVersionSummaryStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentVersionSummaryStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentVersionSummaryStatus value) => value.Value;

    public static explicit operator AgentVersionSummaryStatus(string value) => new(value);

    internal class AgentVersionSummaryStatusSerializer : JsonConverter<AgentVersionSummaryStatus>
    {
        public override AgentVersionSummaryStatus Read(
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
            return new AgentVersionSummaryStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentVersionSummaryStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentVersionSummaryStatus ReadAsPropertyName(
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
            return new AgentVersionSummaryStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentVersionSummaryStatus value,
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
