using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseScorersItemGraderKind.BacktestTrialDetailResponseScorersItemGraderKindSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseScorersItemGraderKind : IStringEnum
{
    public static readonly BacktestTrialDetailResponseScorersItemGraderKind Rubric = new(
        Values.Rubric
    );

    public static readonly BacktestTrialDetailResponseScorersItemGraderKind Classifier = new(
        Values.Classifier
    );

    public static readonly BacktestTrialDetailResponseScorersItemGraderKind Metric = new(
        Values.Metric
    );

    public static readonly BacktestTrialDetailResponseScorersItemGraderKind Embedding = new(
        Values.Embedding
    );

    public static readonly BacktestTrialDetailResponseScorersItemGraderKind Assertion = new(
        Values.Assertion
    );

    public static readonly BacktestTrialDetailResponseScorersItemGraderKind Code = new(Values.Code);

    public BacktestTrialDetailResponseScorersItemGraderKind(string value)
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
    public static BacktestTrialDetailResponseScorersItemGraderKind FromCustom(string value)
    {
        return new BacktestTrialDetailResponseScorersItemGraderKind(value);
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
        BacktestTrialDetailResponseScorersItemGraderKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestTrialDetailResponseScorersItemGraderKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BacktestTrialDetailResponseScorersItemGraderKind value
    ) => value.Value;

    public static explicit operator BacktestTrialDetailResponseScorersItemGraderKind(
        string value
    ) => new(value);

    internal class BacktestTrialDetailResponseScorersItemGraderKindSerializer
        : JsonConverter<BacktestTrialDetailResponseScorersItemGraderKind>
    {
        public override BacktestTrialDetailResponseScorersItemGraderKind Read(
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
            return new BacktestTrialDetailResponseScorersItemGraderKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseScorersItemGraderKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseScorersItemGraderKind ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseScorersItemGraderKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseScorersItemGraderKind value,
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
