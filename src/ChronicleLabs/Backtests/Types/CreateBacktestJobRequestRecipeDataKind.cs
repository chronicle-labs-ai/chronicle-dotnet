using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeDataKind.CreateBacktestJobRequestRecipeDataKindSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeDataKind : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeDataKind Composed = new(Values.Composed);

    public static readonly CreateBacktestJobRequestRecipeDataKind Dataset = new(Values.Dataset);

    public CreateBacktestJobRequestRecipeDataKind(string value)
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
    public static CreateBacktestJobRequestRecipeDataKind FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeDataKind(value);
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

    public static bool operator ==(CreateBacktestJobRequestRecipeDataKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateBacktestJobRequestRecipeDataKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobRequestRecipeDataKind value) =>
        value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeDataKind(string value) =>
        new(value);

    internal class CreateBacktestJobRequestRecipeDataKindSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeDataKind>
    {
        public override CreateBacktestJobRequestRecipeDataKind Read(
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
            return new CreateBacktestJobRequestRecipeDataKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeDataKind ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeDataKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataKind value,
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
        public const string Composed = "composed";

        public const string Dataset = "dataset";
    }
}
