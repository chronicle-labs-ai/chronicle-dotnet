using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus.BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatusSerializer)
)]
[Serializable]
public readonly record struct BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus
    : IStringEnum
{
    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus Ok = new(
        Values.Ok
    );

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus Warn = new(
        Values.Warn
    );

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus Error = new(
        Values.Error
    );

    public BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus(string value)
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
    public static BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus FromCustom(
        string value
    )
    {
        return new BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus(value);
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
        BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus value
    ) => value.Value;

    public static explicit operator BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus(
        string value
    ) => new(value);

    internal class BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatusSerializer
        : JsonConverter<BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus>
    {
        public override BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus Read(
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
            return new BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus ReadAsPropertyName(
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
            return new BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestsAvailabilityDatasetSnapshotsValueTracesItemStatus value,
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
        public const string Ok = "ok";

        public const string Warn = "warn";

        public const string Error = "error";
    }
}
