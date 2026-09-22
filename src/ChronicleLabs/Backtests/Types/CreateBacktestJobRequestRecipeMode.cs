using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeMode.CreateBacktestJobRequestRecipeModeSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeMode : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeMode Replay = new(Values.Replay);

    public static readonly CreateBacktestJobRequestRecipeMode Compare = new(Values.Compare);

    public static readonly CreateBacktestJobRequestRecipeMode Regression = new(Values.Regression);

    public static readonly CreateBacktestJobRequestRecipeMode Suite = new(Values.Suite);

    public CreateBacktestJobRequestRecipeMode(string value)
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
    public static CreateBacktestJobRequestRecipeMode FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeMode(value);
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

    public static bool operator ==(CreateBacktestJobRequestRecipeMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBacktestJobRequestRecipeMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobRequestRecipeMode value) => value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeMode(string value) => new(value);

    internal class CreateBacktestJobRequestRecipeModeSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeMode>
    {
        public override CreateBacktestJobRequestRecipeMode Read(
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
            return new CreateBacktestJobRequestRecipeMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeMode ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeMode value,
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
        public const string Replay = "replay";

        public const string Compare = "compare";

        public const string Regression = "regression";

        public const string Suite = "suite";
    }
}
