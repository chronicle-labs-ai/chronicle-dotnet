using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(TrialEventTrialPhaseChangedPhase.TrialEventTrialPhaseChangedPhaseSerializer))]
[Serializable]
public readonly record struct TrialEventTrialPhaseChangedPhase : IStringEnum
{
    public static readonly TrialEventTrialPhaseChangedPhase Queued = new(Values.Queued);

    public static readonly TrialEventTrialPhaseChangedPhase EnvironmentStart = new(
        Values.EnvironmentStart
    );

    public static readonly TrialEventTrialPhaseChangedPhase EnvironmentReady = new(
        Values.EnvironmentReady
    );

    public static readonly TrialEventTrialPhaseChangedPhase AgentSetup = new(Values.AgentSetup);

    public static readonly TrialEventTrialPhaseChangedPhase AgentRunning = new(Values.AgentRunning);

    public static readonly TrialEventTrialPhaseChangedPhase VerifierRunning = new(
        Values.VerifierRunning
    );

    public static readonly TrialEventTrialPhaseChangedPhase ArtifactCollection = new(
        Values.ArtifactCollection
    );

    public static readonly TrialEventTrialPhaseChangedPhase Cleanup = new(Values.Cleanup);

    public static readonly TrialEventTrialPhaseChangedPhase Done = new(Values.Done);

    public TrialEventTrialPhaseChangedPhase(string value)
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
    public static TrialEventTrialPhaseChangedPhase FromCustom(string value)
    {
        return new TrialEventTrialPhaseChangedPhase(value);
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

    public static bool operator ==(TrialEventTrialPhaseChangedPhase value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TrialEventTrialPhaseChangedPhase value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TrialEventTrialPhaseChangedPhase value) => value.Value;

    public static explicit operator TrialEventTrialPhaseChangedPhase(string value) => new(value);

    internal class TrialEventTrialPhaseChangedPhaseSerializer
        : JsonConverter<TrialEventTrialPhaseChangedPhase>
    {
        public override TrialEventTrialPhaseChangedPhase Read(
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
            return new TrialEventTrialPhaseChangedPhase(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TrialEventTrialPhaseChangedPhase value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TrialEventTrialPhaseChangedPhase ReadAsPropertyName(
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
            return new TrialEventTrialPhaseChangedPhase(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TrialEventTrialPhaseChangedPhase value,
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
        public const string Queued = "queued";

        public const string EnvironmentStart = "environment-start";

        public const string EnvironmentReady = "environment-ready";

        public const string AgentSetup = "agent-setup";

        public const string AgentRunning = "agent-running";

        public const string VerifierRunning = "verifier-running";

        public const string ArtifactCollection = "artifact-collection";

        public const string Cleanup = "cleanup";

        public const string Done = "done";
    }
}
