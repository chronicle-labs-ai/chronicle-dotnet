using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeGradersItemSource.CreateBacktestJobRequestRecipeGradersItemSourceSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeGradersItemSource : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeGradersItemSource Proposed = new(
        Values.Proposed
    );

    public static readonly CreateBacktestJobRequestRecipeGradersItemSource Library = new(
        Values.Library
    );

    public static readonly CreateBacktestJobRequestRecipeGradersItemSource Custom = new(
        Values.Custom
    );

    public static readonly CreateBacktestJobRequestRecipeGradersItemSource Dataset = new(
        Values.Dataset
    );

    public CreateBacktestJobRequestRecipeGradersItemSource(string value)
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
    public static CreateBacktestJobRequestRecipeGradersItemSource FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeGradersItemSource(value);
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
        CreateBacktestJobRequestRecipeGradersItemSource value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeGradersItemSource value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobRequestRecipeGradersItemSource value) =>
        value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeGradersItemSource(string value) =>
        new(value);

    internal class CreateBacktestJobRequestRecipeGradersItemSourceSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeGradersItemSource>
    {
        public override CreateBacktestJobRequestRecipeGradersItemSource Read(
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
            return new CreateBacktestJobRequestRecipeGradersItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeGradersItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeGradersItemSource ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeGradersItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeGradersItemSource value,
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
        public const string Proposed = "proposed";

        public const string Library = "library";

        public const string Custom = "custom";

        public const string Dataset = "dataset";
    }
}
