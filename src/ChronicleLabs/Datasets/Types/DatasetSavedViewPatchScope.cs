using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(DatasetSavedViewPatchScope.DatasetSavedViewPatchScopeSerializer))]
[Serializable]
public readonly record struct DatasetSavedViewPatchScope : IStringEnum
{
    public static readonly DatasetSavedViewPatchScope Personal = new(Values.Personal);

    public static readonly DatasetSavedViewPatchScope Workspace = new(Values.Workspace);

    public DatasetSavedViewPatchScope(string value)
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
    public static DatasetSavedViewPatchScope FromCustom(string value)
    {
        return new DatasetSavedViewPatchScope(value);
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

    public static bool operator ==(DatasetSavedViewPatchScope value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DatasetSavedViewPatchScope value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DatasetSavedViewPatchScope value) => value.Value;

    public static explicit operator DatasetSavedViewPatchScope(string value) => new(value);

    internal class DatasetSavedViewPatchScopeSerializer : JsonConverter<DatasetSavedViewPatchScope>
    {
        public override DatasetSavedViewPatchScope Read(
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
            return new DatasetSavedViewPatchScope(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DatasetSavedViewPatchScope value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DatasetSavedViewPatchScope ReadAsPropertyName(
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
            return new DatasetSavedViewPatchScope(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DatasetSavedViewPatchScope value,
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
