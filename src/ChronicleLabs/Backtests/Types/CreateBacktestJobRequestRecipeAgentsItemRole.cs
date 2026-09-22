using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(CreateBacktestJobRequestRecipeAgentsItemRole.CreateBacktestJobRequestRecipeAgentsItemRoleSerializer)
)]
[Serializable]
public readonly record struct CreateBacktestJobRequestRecipeAgentsItemRole : IStringEnum
{
    public static readonly CreateBacktestJobRequestRecipeAgentsItemRole Baseline = new(
        Values.Baseline
    );

    public static readonly CreateBacktestJobRequestRecipeAgentsItemRole Candidate = new(
        Values.Candidate
    );

    public CreateBacktestJobRequestRecipeAgentsItemRole(string value)
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
    public static CreateBacktestJobRequestRecipeAgentsItemRole FromCustom(string value)
    {
        return new CreateBacktestJobRequestRecipeAgentsItemRole(value);
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
        CreateBacktestJobRequestRecipeAgentsItemRole value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateBacktestJobRequestRecipeAgentsItemRole value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateBacktestJobRequestRecipeAgentsItemRole value) =>
        value.Value;

    public static explicit operator CreateBacktestJobRequestRecipeAgentsItemRole(string value) =>
        new(value);

    internal class CreateBacktestJobRequestRecipeAgentsItemRoleSerializer
        : JsonConverter<CreateBacktestJobRequestRecipeAgentsItemRole>
    {
        public override CreateBacktestJobRequestRecipeAgentsItemRole Read(
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
            return new CreateBacktestJobRequestRecipeAgentsItemRole(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeAgentsItemRole value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateBacktestJobRequestRecipeAgentsItemRole ReadAsPropertyName(
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
            return new CreateBacktestJobRequestRecipeAgentsItemRole(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateBacktestJobRequestRecipeAgentsItemRole value,
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
        public const string Baseline = "baseline";

        public const string Candidate = "candidate";
    }
}
