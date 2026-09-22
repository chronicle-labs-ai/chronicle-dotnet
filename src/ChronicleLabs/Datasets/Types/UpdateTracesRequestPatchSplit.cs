using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(UpdateTracesRequestPatchSplit.UpdateTracesRequestPatchSplitSerializer))]
[Serializable]
public readonly record struct UpdateTracesRequestPatchSplit : IStringEnum
{
    public static readonly UpdateTracesRequestPatchSplit Train = new(Values.Train);

    public static readonly UpdateTracesRequestPatchSplit Validation = new(Values.Validation);

    public static readonly UpdateTracesRequestPatchSplit Test = new(Values.Test);

    public UpdateTracesRequestPatchSplit(string value)
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
    public static UpdateTracesRequestPatchSplit FromCustom(string value)
    {
        return new UpdateTracesRequestPatchSplit(value);
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

    public static bool operator ==(UpdateTracesRequestPatchSplit value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateTracesRequestPatchSplit value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateTracesRequestPatchSplit value) => value.Value;

    public static explicit operator UpdateTracesRequestPatchSplit(string value) => new(value);

    internal class UpdateTracesRequestPatchSplitSerializer
        : JsonConverter<UpdateTracesRequestPatchSplit>
    {
        public override UpdateTracesRequestPatchSplit Read(
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
            return new UpdateTracesRequestPatchSplit(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateTracesRequestPatchSplit value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateTracesRequestPatchSplit ReadAsPropertyName(
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
            return new UpdateTracesRequestPatchSplit(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateTracesRequestPatchSplit value,
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
        public const string Train = "train";

        public const string Validation = "validation";

        public const string Test = "test";
    }
}
