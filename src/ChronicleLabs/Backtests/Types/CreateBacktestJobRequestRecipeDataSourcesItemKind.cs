using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeDataSourcesItemKind.CreateBacktestJobRequestRecipeDataSourcesItemKindSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeDataSourcesItemKind : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeDataSourcesItemKind Prod = new(
        Values.Prod
    );

    public static readonly CreateBacktestJobRequestRecipeDataSourcesItemKind Dataset = new(
        Values.Dataset
    );

    public CreateBacktestJobRequestRecipeDataSourcesItemKind(string value)
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
    public static CreateBacktestJobRequestRecipeDataSourcesItemKind FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeDataSourcesItemKind(value);
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
        CreateBacktestJobRequestRecipeDataSourcesItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeDataSourcesItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateBacktestJobRequestRecipeDataSourcesItemKind value
    ) => value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeDataSourcesItemKind(
        string value
    ) => new(value);

    internal class CreateBacktestJobRequestRecipeDataSourcesItemKindSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeDataSourcesItemKind>
    {
        public override CreateBacktestJobRequestRecipeDataSourcesItemKind Read(
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
            return new CreateBacktestJobRequestRecipeDataSourcesItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataSourcesItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeDataSourcesItemKind ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeDataSourcesItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataSourcesItemKind value,
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
        public const string Prod = "prod";

        public const string Dataset = "dataset";
    }
}
