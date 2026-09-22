using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestTrialDetailResponseScorersItemGraderCodeLanguage.BacktestTrialDetailResponseScorersItemGraderCodeLanguageSerializer)
)]
[Serializable]
public readonly record struct BacktestTrialDetailResponseScorersItemGraderCodeLanguage : IStringEnum
{
    public static readonly BacktestTrialDetailResponseScorersItemGraderCodeLanguage Python = new(
        Values.Python
    );

    public static readonly BacktestTrialDetailResponseScorersItemGraderCodeLanguage Typescript =
        new(Values.Typescript);

    public BacktestTrialDetailResponseScorersItemGraderCodeLanguage(string value)
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
    public static BacktestTrialDetailResponseScorersItemGraderCodeLanguage FromCustom(string value)
    {
        return new BacktestTrialDetailResponseScorersItemGraderCodeLanguage(value);
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
        BacktestTrialDetailResponseScorersItemGraderCodeLanguage value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestTrialDetailResponseScorersItemGraderCodeLanguage value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BacktestTrialDetailResponseScorersItemGraderCodeLanguage value
    ) => value.Value;

    public static explicit operator BacktestTrialDetailResponseScorersItemGraderCodeLanguage(
        string value
    ) => new(value);

    internal class BacktestTrialDetailResponseScorersItemGraderCodeLanguageSerializer
        : JsonConverter<BacktestTrialDetailResponseScorersItemGraderCodeLanguage>
    {
        public override BacktestTrialDetailResponseScorersItemGraderCodeLanguage Read(
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
            return new BacktestTrialDetailResponseScorersItemGraderCodeLanguage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseScorersItemGraderCodeLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestTrialDetailResponseScorersItemGraderCodeLanguage ReadAsPropertyName(
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
            return new BacktestTrialDetailResponseScorersItemGraderCodeLanguage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestTrialDetailResponseScorersItemGraderCodeLanguage value,
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
        public const string Python = "python";

        public const string Typescript = "typescript";
    }
}
