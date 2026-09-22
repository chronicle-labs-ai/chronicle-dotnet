using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseArtifactsItemKind.BacktestTrialDetailResponseArtifactsItemKindSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseArtifactsItemKind : IStringEnum
{
    public static readonly BacktestTrialDetailResponseArtifactsItemKind AgentLog = new(
        Values.AgentLog
    );

    public static readonly BacktestTrialDetailResponseArtifactsItemKind VerifierLog = new(
        Values.VerifierLog
    );

    public static readonly BacktestTrialDetailResponseArtifactsItemKind Trajectory = new(
        Values.Trajectory
    );

    public static readonly BacktestTrialDetailResponseArtifactsItemKind Screenshot = new(
        Values.Screenshot
    );

    public static readonly BacktestTrialDetailResponseArtifactsItemKind RewardJson = new(
        Values.RewardJson
    );

    public static readonly BacktestTrialDetailResponseArtifactsItemKind RewardTxt = new(
        Values.RewardTxt
    );

    public static readonly BacktestTrialDetailResponseArtifactsItemKind Tar = new(Values.Tar);

    public static readonly BacktestTrialDetailResponseArtifactsItemKind Other = new(Values.Other);

    public BacktestTrialDetailResponseArtifactsItemKind(string value)
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
    public static BacktestTrialDetailResponseArtifactsItemKind FromCustom(string value)
    {
        return new BacktestTrialDetailResponseArtifactsItemKind(value);
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
        BacktestTrialDetailResponseArtifactsItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestTrialDetailResponseArtifactsItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BacktestTrialDetailResponseArtifactsItemKind value) =>
        value.Value;

    public static explicit operator BacktestTrialDetailResponseArtifactsItemKind(string value) =>
        new(value);

    internal class BacktestTrialDetailResponseArtifactsItemKindSerializer
        : JsonConverter<BacktestTrialDetailResponseArtifactsItemKind>
    {
        public override BacktestTrialDetailResponseArtifactsItemKind Read(
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
            return new BacktestTrialDetailResponseArtifactsItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseArtifactsItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseArtifactsItemKind ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseArtifactsItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseArtifactsItemKind value,
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
        public const string AgentLog = "agent-log";

        public const string VerifierLog = "verifier-log";

        public const string Trajectory = "trajectory";

        public const string Screenshot = "screenshot";

        public const string RewardJson = "reward-json";

        public const string RewardTxt = "reward-txt";

        public const string Tar = "tar";

        public const string Other = "other";
    }
}
