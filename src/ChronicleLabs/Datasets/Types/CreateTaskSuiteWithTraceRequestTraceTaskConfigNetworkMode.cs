using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode.CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkModeSerializer)
)]
[Serializable]
public readonly record struct CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode
    : IStringEnum
{
    public static readonly CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode Public = new(
        Values.Public
    );

    public static readonly CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode NoNetwork =
        new(Values.NoNetwork);

    public CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode(string value)
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
    public static CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode FromCustom(string value)
    {
        return new CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode(value);
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
        CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode value
    ) => value.Value;

    public static explicit operator CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode(
        string value
    ) => new(value);

    internal class CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkModeSerializer
        : JsonConverter<CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode>
    {
        public override CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode Read(
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
            return new CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode ReadAsPropertyName(
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
            return new CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTaskSuiteWithTraceRequestTraceTaskConfigNetworkMode value,
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
        public const string Public = "public";

        public const string NoNetwork = "no-network";
    }
}
