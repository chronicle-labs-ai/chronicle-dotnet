using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeDataScenariosItemKind.CreateBacktestJobRequestRecipeDataScenariosItemKindSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeDataScenariosItemKind : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemKind Adversarial = new(
        Values.Adversarial
    );

    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemKind NonEnglish = new(
        Values.NonEnglish
    );

    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemKind ToolFailure = new(
        Values.ToolFailure
    );

    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemKind LongTurn = new(
        Values.LongTurn
    );

    public CreateBacktestJobRequestRecipeDataScenariosItemKind(string value)
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
    public static CreateBacktestJobRequestRecipeDataScenariosItemKind FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeDataScenariosItemKind(value);
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
        CreateBacktestJobRequestRecipeDataScenariosItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeDataScenariosItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateBacktestJobRequestRecipeDataScenariosItemKind value
    ) => value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeDataScenariosItemKind(
        string value
    ) => new(value);

    internal class CreateBacktestJobRequestRecipeDataScenariosItemKindSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeDataScenariosItemKind>
    {
        public override CreateBacktestJobRequestRecipeDataScenariosItemKind Read(
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
            return new CreateBacktestJobRequestRecipeDataScenariosItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataScenariosItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeDataScenariosItemKind ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeDataScenariosItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataScenariosItemKind value,
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
        public const string Adversarial = "adversarial";

        public const string NonEnglish = "nonEnglish";

        public const string ToolFailure = "toolFailure";

        public const string LongTurn = "longTurn";
    }
}
