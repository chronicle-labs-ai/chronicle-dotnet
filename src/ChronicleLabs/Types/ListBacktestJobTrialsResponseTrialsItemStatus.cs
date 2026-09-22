using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(ListBacktestJobTrialsResponseTrialsItemStatus.ListBacktestJobTrialsResponseTrialsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ListBacktestJobTrialsResponseTrialsItemStatus : IStringEnum
{
    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Pending = new(
        Values.Pending
    );

    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Setup = new(Values.Setup);

    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Running = new(
        Values.Running
    );

    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Verifying = new(
        Values.Verifying
    );

    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Succeeded = new(
        Values.Succeeded
    );

    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Failed = new(
        Values.Failed
    );

    public static readonly ListBacktestJobTrialsResponseTrialsItemStatus Cancelled = new(
        Values.Cancelled
    );

    public ListBacktestJobTrialsResponseTrialsItemStatus(string value)
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
    public static ListBacktestJobTrialsResponseTrialsItemStatus FromCustom(string value)
    {
        return new ListBacktestJobTrialsResponseTrialsItemStatus(value);
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
        ListBacktestJobTrialsResponseTrialsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ListBacktestJobTrialsResponseTrialsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ListBacktestJobTrialsResponseTrialsItemStatus value) =>
        value.Value;

    public static explicit operator ListBacktestJobTrialsResponseTrialsItemStatus(string value) =>
        new(value);

    internal class ListBacktestJobTrialsResponseTrialsItemStatusSerializer
        : JsonConverter<ListBacktestJobTrialsResponseTrialsItemStatus>
    {
        public override ListBacktestJobTrialsResponseTrialsItemStatus Read(
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
            return new ListBacktestJobTrialsResponseTrialsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ListBacktestJobTrialsResponseTrialsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ListBacktestJobTrialsResponseTrialsItemStatus ReadAsPropertyName(
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
            return new ListBacktestJobTrialsResponseTrialsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ListBacktestJobTrialsResponseTrialsItemStatus value,
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
        public const string Pending = "pending";

        public const string Setup = "setup";

        public const string Running = "running";

        public const string Verifying = "verifying";

        public const string Succeeded = "succeeded";

        public const string Failed = "failed";

        public const string Cancelled = "cancelled";
    }
}
