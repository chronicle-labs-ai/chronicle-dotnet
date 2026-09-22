using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind.BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKindSerializer)
)]
[Serializable]
public readonly record struct BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind
    : IStringEnum
{
    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Rubric =
        new(Values.Rubric);

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Classifier =
        new(Values.Classifier);

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Metric =
        new(Values.Metric);

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Embedding =
        new(Values.Embedding);

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Assertion =
        new(Values.Assertion);

    public static readonly BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Code =
        new(Values.Code);

    public BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind(string value)
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
    public static BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind FromCustom(
        string value
    )
    {
        return new BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind(value);
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
        BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind value
    ) => value.Value;

    public static explicit operator BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind(
        string value
    ) => new(value);

    internal class BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKindSerializer
        : JsonConverter<BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind>
    {
        public override BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind Read(
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
            return new BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind ReadAsPropertyName(
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
            return new BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestsAvailabilityDatasetSnapshotsValueTasksItemVerifiersItemKind value,
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
        public const string Rubric = "rubric";

        public const string Classifier = "classifier";

        public const string Metric = "metric";

        public const string Embedding = "embedding";

        public const string Assertion = "assertion";

        public const string Code = "code";
    }
}
