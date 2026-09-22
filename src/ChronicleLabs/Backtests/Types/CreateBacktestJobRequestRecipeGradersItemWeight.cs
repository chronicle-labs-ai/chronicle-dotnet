using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeGradersItemWeight.CreateBacktestJobRequestRecipeGradersItemWeightSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeGradersItemWeight : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeGradersItemWeight Low = new(Values.Low);

    public static readonly CreateBacktestJobRequestRecipeGradersItemWeight Med = new(Values.Med);

    public static readonly CreateBacktestJobRequestRecipeGradersItemWeight High = new(Values.High);

    public CreateBacktestJobRequestRecipeGradersItemWeight(string value)
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
    public static CreateBacktestJobRequestRecipeGradersItemWeight FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeGradersItemWeight(value);
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
        CreateBacktestJobRequestRecipeGradersItemWeight value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeGradersItemWeight value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobRequestRecipeGradersItemWeight value) =>
        value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeGradersItemWeight(string value) =>
        new(value);

    internal class CreateBacktestJobRequestRecipeGradersItemWeightSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeGradersItemWeight>
    {
        public override CreateBacktestJobRequestRecipeGradersItemWeight Read(
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
            return new CreateBacktestJobRequestRecipeGradersItemWeight(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeGradersItemWeight value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeGradersItemWeight ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeGradersItemWeight(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeGradersItemWeight value,
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
        public const string Low = "low";

        public const string Med = "med";

        public const string High = "high";
    }
}
