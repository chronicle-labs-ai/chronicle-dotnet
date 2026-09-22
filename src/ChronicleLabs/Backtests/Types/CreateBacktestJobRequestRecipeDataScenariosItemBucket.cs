using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeDataScenariosItemBucket.CreateBacktestJobRequestRecipeDataScenariosItemBucketSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeDataScenariosItemBucket : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemBucket Captured = new(
        Values.Captured
    );

    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemBucket Adjacent = new(
        Values.Adjacent
    );

    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemBucket Emerging = new(
        Values.Emerging
    );

    public static readonly CreateBacktestJobRequestRecipeDataScenariosItemBucket Edge = new(
        Values.Edge
    );

    public CreateBacktestJobRequestRecipeDataScenariosItemBucket(string value)
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
    public static CreateBacktestJobRequestRecipeDataScenariosItemBucket FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeDataScenariosItemBucket(value);
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
        CreateBacktestJobRequestRecipeDataScenariosItemBucket value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeDataScenariosItemBucket value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateBacktestJobRequestRecipeDataScenariosItemBucket value
    ) => value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeDataScenariosItemBucket(
        string value
    ) => new(value);

    internal class CreateBacktestJobRequestRecipeDataScenariosItemBucketSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeDataScenariosItemBucket>
    {
        public override CreateBacktestJobRequestRecipeDataScenariosItemBucket Read(
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
            return new CreateBacktestJobRequestRecipeDataScenariosItemBucket(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataScenariosItemBucket value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeDataScenariosItemBucket ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeDataScenariosItemBucket(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeDataScenariosItemBucket value,
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
        public const string Captured = "captured";

        public const string Adjacent = "adjacent";

        public const string Emerging = "emerging";

        public const string Edge = "edge";
    }
}
