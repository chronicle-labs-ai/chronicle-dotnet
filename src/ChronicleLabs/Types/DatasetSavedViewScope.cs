using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(DatasetSavedViewScope.DatasetSavedViewScopeSerializer))]
[Serializable]
public readonly record struct DatasetSavedViewScope : IStringEnum
{
    public static readonly DatasetSavedViewScope Personal = new(Values.Personal);

    public static readonly DatasetSavedViewScope Workspace = new(Values.Workspace);

    public DatasetSavedViewScope(string value)
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
    public static DatasetSavedViewScope FromCustom(string value)
    {
        return new DatasetSavedViewScope(value);
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

    public static bool operator ==(DatasetSavedViewScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DatasetSavedViewScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DatasetSavedViewScope value) => value.Value;

    public static explicit operator DatasetSavedViewScope(string value) => new(value);

    internal class DatasetSavedViewScopeSerializer : JsonConverter<DatasetSavedViewScope>
    {
        public override DatasetSavedViewScope Read(
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
            return new DatasetSavedViewScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DatasetSavedViewScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DatasetSavedViewScope ReadAsPropertyName(
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
            return new DatasetSavedViewScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DatasetSavedViewScope value,
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
