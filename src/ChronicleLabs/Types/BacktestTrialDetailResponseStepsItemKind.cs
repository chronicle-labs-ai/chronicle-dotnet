using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseStepsItemKind.BacktestTrialDetailResponseStepsItemKindSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseStepsItemKind : IStringEnum
{
    public static readonly BacktestTrialDetailResponseStepsItemKind SeedEvent = new(
        Values.SeedEvent
    );

    public static readonly BacktestTrialDetailResponseStepsItemKind StateChange = new(
        Values.StateChange
    );

    public static readonly BacktestTrialDetailResponseStepsItemKind ToolCall = new(Values.ToolCall);

    public static readonly BacktestTrialDetailResponseStepsItemKind Message = new(Values.Message);

    public static readonly BacktestTrialDetailResponseStepsItemKind FinalAnswer = new(
        Values.FinalAnswer
    );

    public static readonly BacktestTrialDetailResponseStepsItemKind Phase = new(Values.Phase);

    public static readonly BacktestTrialDetailResponseStepsItemKind VerifierRun = new(
        Values.VerifierRun
    );

    public static readonly BacktestTrialDetailResponseStepsItemKind Grade = new(Values.Grade);

    public BacktestTrialDetailResponseStepsItemKind(string value)
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
    public static BacktestTrialDetailResponseStepsItemKind FromCustom(string value)
    {
        return new BacktestTrialDetailResponseStepsItemKind(value);
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
        BacktestTrialDetailResponseStepsItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestTrialDetailResponseStepsItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BacktestTrialDetailResponseStepsItemKind value) =>
        value.Value;

    public static explicit operator BacktestTrialDetailResponseStepsItemKind(string value) =>
        new(value);

    internal class BacktestTrialDetailResponseStepsItemKindSerializer
        : JsonConverter<BacktestTrialDetailResponseStepsItemKind>
    {
        public override BacktestTrialDetailResponseStepsItemKind Read(
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
            return new BacktestTrialDetailResponseStepsItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseStepsItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseStepsItemKind ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseStepsItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseStepsItemKind value,
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
        public const string SeedEvent = "seed-event";

        public const string StateChange = "state-change";

        public const string ToolCall = "tool-call";

        public const string Message = "message";

        public const string FinalAnswer = "final-answer";

        public const string Phase = "phase";

        public const string VerifierRun = "verifier-run";

        public const string Grade = "grade";
    }
}
