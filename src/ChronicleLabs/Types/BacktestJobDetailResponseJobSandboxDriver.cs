using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestJobDetailResponseJobSandboxDriver.BacktestJobDetailResponseJobSandboxDriverSerializer)
)]
[Serializable]
public readonly record struct BacktestJobDetailResponseJobSandboxDriver : IStringEnum
{
    public static readonly BacktestJobDetailResponseJobSandboxDriver Docker = new(Values.Docker);

    public static readonly BacktestJobDetailResponseJobSandboxDriver Daytona = new(Values.Daytona);

    public static readonly BacktestJobDetailResponseJobSandboxDriver Mock = new(Values.Mock);

    public BacktestJobDetailResponseJobSandboxDriver(string value)
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
    public static BacktestJobDetailResponseJobSandboxDriver FromCustom(string value)
    {
        return new BacktestJobDetailResponseJobSandboxDriver(value);
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
        BacktestJobDetailResponseJobSandboxDriver value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestJobDetailResponseJobSandboxDriver value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BacktestJobDetailResponseJobSandboxDriver value) =>
        value.Value;

    public static explicit operator BacktestJobDetailResponseJobSandboxDriver(string value) =>
        new(value);

    internal class BacktestJobDetailResponseJobSandboxDriverSerializer
        : JsonConverter<BacktestJobDetailResponseJobSandboxDriver>
    {
        public override BacktestJobDetailResponseJobSandboxDriver Read(
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
            return new BacktestJobDetailResponseJobSandboxDriver(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseJobSandboxDriver value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestJobDetailResponseJobSandboxDriver ReadAsPropertyName(
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
            return new BacktestJobDetailResponseJobSandboxDriver(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestJobDetailResponseJobSandboxDriver value,
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
        public const string Docker = "docker";

        public const string Daytona = "daytona";

        public const string Mock = "mock";
    }
}
