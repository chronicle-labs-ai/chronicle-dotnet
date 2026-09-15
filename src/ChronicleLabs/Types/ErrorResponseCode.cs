using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(ErrorResponseCode.ErrorResponseCodeSerializer))]
[Serializable]
public readonly record struct ErrorResponseCode : IStringEnum
{
    public static readonly ErrorResponseCode NotFound = new(Values.NotFound);

    public static readonly ErrorResponseCode BadRequest = new(Values.BadRequest);

    public static readonly ErrorResponseCode Unauthorized = new(Values.Unauthorized);

    public static readonly ErrorResponseCode ValidationError = new(Values.ValidationError);

    public static readonly ErrorResponseCode UnsupportedMediaType = new(
        Values.UnsupportedMediaType
    );

    public static readonly ErrorResponseCode PayloadTooLarge = new(Values.PayloadTooLarge);

    public static readonly ErrorResponseCode RateLimited = new(Values.RateLimited);

    public static readonly ErrorResponseCode StreamReplayLimitExceeded = new(
        Values.StreamReplayLimitExceeded
    );

    public static readonly ErrorResponseCode StreamUnavailable = new(Values.StreamUnavailable);

    public static readonly ErrorResponseCode ServiceOverloaded = new(Values.ServiceOverloaded);

    public static readonly ErrorResponseCode RequestTimeout = new(Values.RequestTimeout);

    public static readonly ErrorResponseCode StreamError = new(Values.StreamError);

    public static readonly ErrorResponseCode StoreError = new(Values.StoreError);

    public static readonly ErrorResponseCode InternalError = new(Values.InternalError);

    public ErrorResponseCode(string value)
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
    public static ErrorResponseCode FromCustom(string value)
    {
        return new ErrorResponseCode(value);
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

    public static bool operator ==(ErrorResponseCode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ErrorResponseCode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ErrorResponseCode value) => value.Value;

    public static explicit operator ErrorResponseCode(string value) => new(value);

    internal class ErrorResponseCodeSerializer : JsonConverter<ErrorResponseCode>
    {
        public override ErrorResponseCode Read(
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
            return new ErrorResponseCode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ErrorResponseCode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ErrorResponseCode ReadAsPropertyName(
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
            return new ErrorResponseCode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ErrorResponseCode value,
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
        public const string NotFound = "not_found";

        public const string BadRequest = "bad_request";

        public const string Unauthorized = "unauthorized";

        public const string ValidationError = "validation_error";

        public const string UnsupportedMediaType = "unsupported_media_type";

        public const string PayloadTooLarge = "payload_too_large";

        public const string RateLimited = "rate_limited";

        public const string StreamReplayLimitExceeded = "stream_replay_limit_exceeded";

        public const string StreamUnavailable = "stream_unavailable";

        public const string ServiceOverloaded = "service_overloaded";

        public const string RequestTimeout = "request_timeout";

        public const string StreamError = "stream_error";

        public const string StoreError = "store_error";

        public const string InternalError = "internal_error";
    }
}
