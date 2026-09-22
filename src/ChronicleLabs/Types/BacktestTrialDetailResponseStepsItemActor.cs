using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseStepsItemActor.BacktestTrialDetailResponseStepsItemActorSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseStepsItemActor : IStringEnum
{
    public static readonly BacktestTrialDetailResponseStepsItemActor Environment = new(
        Values.Environment
    );

    public static readonly BacktestTrialDetailResponseStepsItemActor Agent = new(Values.Agent);

    public static readonly BacktestTrialDetailResponseStepsItemActor Verifier = new(
        Values.Verifier
    );

    public static readonly BacktestTrialDetailResponseStepsItemActor Grader = new(Values.Grader);

    public BacktestTrialDetailResponseStepsItemActor(string value)
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
    public static BacktestTrialDetailResponseStepsItemActor FromCustom(string value)
    {
        return new BacktestTrialDetailResponseStepsItemActor(value);
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
        BacktestTrialDetailResponseStepsItemActor value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestTrialDetailResponseStepsItemActor value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BacktestTrialDetailResponseStepsItemActor value) =>
        value.Value;

    public static explicit operator BacktestTrialDetailResponseStepsItemActor(string value) =>
        new(value);

    internal class BacktestTrialDetailResponseStepsItemActorSerializer
        : JsonConverter<BacktestTrialDetailResponseStepsItemActor>
    {
        public override BacktestTrialDetailResponseStepsItemActor Read(
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
            return new BacktestTrialDetailResponseStepsItemActor(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseStepsItemActor value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseStepsItemActor ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseStepsItemActor(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseStepsItemActor value,
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
        public const string Environment = "environment";

        public const string Agent = "agent";

        public const string Verifier = "verifier";

        public const string Grader = "grader";
    }
}
