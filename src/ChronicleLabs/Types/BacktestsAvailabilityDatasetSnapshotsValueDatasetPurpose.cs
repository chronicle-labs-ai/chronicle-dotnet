using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose.BacktestsAvailabilityDatasetSnapshotsValueDatasetPurposeSerializer)
)]
[Serializable]
public readonly record struct BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose : IStringEnum
{
    public static readonly BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose Eval = new(
        Values.Eval
    );

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose Training = new(
        Values.Training
    );

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose Replay = new(
        Values.Replay
    );

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose Review = new(
        Values.Review
    );

    public BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose(string value)
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
    public static BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose FromCustom(string value)
    {
        return new BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose(value);
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
        BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose value
    ) => value.Value;

    public static explicit operator BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose(
        string value
    ) => new(value);

    internal class BacktestsAvailabilityDatasetSnapshotsValueDatasetPurposeSerializer
        : JsonConverter<BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose>
    {
        public override BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose Read(
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
            return new BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose ReadAsPropertyName(
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
            return new BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestsAvailabilityDatasetSnapshotsValueDatasetPurpose value,
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
        public const string Eval = "eval";

        public const string Training = "training";

        public const string Replay = "replay";

        public const string Review = "review";
    }
}
