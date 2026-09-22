using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(CreateSavedViewRequestScope.CreateSavedViewRequestScopeSerializer))]
[Serializable]
public readonly record struct CreateSavedViewRequestScope : IStringEnum
{
    public static readonly CreateSavedViewRequestScope Personal = new(Values.Personal);

    public static readonly CreateSavedViewRequestScope Workspace = new(Values.Workspace);

    public CreateSavedViewRequestScope(string value)
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
    public static CreateSavedViewRequestScope FromCustom(string value)
    {
        return new CreateSavedViewRequestScope(value);
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

    public static bool operator ==(CreateSavedViewRequestScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSavedViewRequestScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSavedViewRequestScope value) => value.Value;

    public static explicit operator CreateSavedViewRequestScope(string value) => new(value);

    internal class CreateSavedViewRequestScopeSerializer
        : JsonConverter<CreateSavedViewRequestScope>
    {
        public override CreateSavedViewRequestScope Read(
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
            return new CreateSavedViewRequestScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSavedViewRequestScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSavedViewRequestScope ReadAsPropertyName(
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
            return new CreateSavedViewRequestScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSavedViewRequestScope value,
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
        public const string Personal = "personal";

        public const string Workspace = "workspace";
    }
}
