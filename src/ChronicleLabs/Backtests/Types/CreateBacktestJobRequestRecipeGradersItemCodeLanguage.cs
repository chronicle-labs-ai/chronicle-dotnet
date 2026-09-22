using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeGradersItemCodeLanguage.CreateBacktestJobRequestRecipeGradersItemCodeLanguageSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeGradersItemCodeLanguage : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeGradersItemCodeLanguage Python = new(
        Values.Python
    );

    public static readonly CreateBacktestJobRequestRecipeGradersItemCodeLanguage Typescript = new(
        Values.Typescript
    );

    public CreateBacktestJobRequestRecipeGradersItemCodeLanguage(string value)
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
    public static CreateBacktestJobRequestRecipeGradersItemCodeLanguage FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeGradersItemCodeLanguage(value);
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
        CreateBacktestJobRequestRecipeGradersItemCodeLanguage value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeGradersItemCodeLanguage value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateBacktestJobRequestRecipeGradersItemCodeLanguage value
    ) => value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeGradersItemCodeLanguage(
        string value
    ) => new(value);

    internal class CreateBacktestJobRequestRecipeGradersItemCodeLanguageSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeGradersItemCodeLanguage>
    {
        public override CreateBacktestJobRequestRecipeGradersItemCodeLanguage Read(
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
            return new CreateBacktestJobRequestRecipeGradersItemCodeLanguage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeGradersItemCodeLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeGradersItemCodeLanguage ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeGradersItemCodeLanguage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeGradersItemCodeLanguage value,
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
