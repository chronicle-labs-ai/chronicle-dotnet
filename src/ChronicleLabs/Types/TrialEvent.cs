// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

/// <summary>
/// Event emitted by the orchestrator on its broadcast channel; the SSE handler at `/api/platform/backtests/jobs/:id/stream` re-emits these to the dashboard + CLI. Variants match the dashboard's `BacktestsEvent` plus per-trial fine grain.
/// </summary>
[JsonConverter(typeof(TrialEvent.JsonConverter))]
[Serializable]
public record TrialEvent
{
    internal TrialEvent(string type, object? value)
    {
        Kind = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of TrialEvent with <see cref="TrialEvent.JobStarted"/>.
    /// </summary>
    public TrialEvent(TrialEvent.JobStarted value)
    {
        Kind = "job-started";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TrialEvent with <see cref="TrialEvent.TrialPhaseChanged"/>.
    /// </summary>
    public TrialEvent(TrialEvent.TrialPhaseChanged value)
    {
        Kind = "trial-phase-changed";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TrialEvent with <see cref="TrialEvent.TrialRewardsRecorded"/>.
    /// </summary>
    public TrialEvent(TrialEvent.TrialRewardsRecorded value)
    {
        Kind = "trial-rewards-recorded";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TrialEvent with <see cref="TrialEvent.TrialFinished"/>.
    /// </summary>
    public TrialEvent(TrialEvent.TrialFinished value)
    {
        Kind = "trial-finished";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of TrialEvent with <see cref="TrialEvent.JobFinished"/>.
    /// </summary>
    public TrialEvent(TrialEvent.JobFinished value)
    {
        Kind = "job-finished";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("kind")]
    public string Kind { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "job-started"
    /// </summary>
    public bool IsJobStarted => Kind == "job-started";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "trial-phase-changed"
    /// </summary>
    public bool IsTrialPhaseChanged => Kind == "trial-phase-changed";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "trial-rewards-recorded"
    /// </summary>
    public bool IsTrialRewardsRecorded => Kind == "trial-rewards-recorded";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "trial-finished"
    /// </summary>
    public bool IsTrialFinished => Kind == "trial-finished";

    /// <summary>
    /// Returns true if <see cref="Kind"/> is "job-finished"
    /// </summary>
    public bool IsJobFinished => Kind == "job-finished";

    /// <summary>
    /// Returns the value as a <see cref="ChronicleLabs.TrialEventJobStarted"/> if <see cref="Kind"/> is 'job-started', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'job-started'.</exception>
    public ChronicleLabs.TrialEventJobStarted AsJobStarted() =>
        IsJobStarted
            ? (ChronicleLabs.TrialEventJobStarted)Value!
            : throw new global::System.Exception("TrialEvent.Kind is not 'job-started'");

    /// <summary>
    /// Returns the value as a <see cref="ChronicleLabs.TrialEventTrialPhaseChanged"/> if <see cref="Kind"/> is 'trial-phase-changed', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'trial-phase-changed'.</exception>
    public ChronicleLabs.TrialEventTrialPhaseChanged AsTrialPhaseChanged() =>
        IsTrialPhaseChanged
            ? (ChronicleLabs.TrialEventTrialPhaseChanged)Value!
            : throw new global::System.Exception("TrialEvent.Kind is not 'trial-phase-changed'");

    /// <summary>
    /// Returns the value as a <see cref="ChronicleLabs.TrialEventTrialRewardsRecorded"/> if <see cref="Kind"/> is 'trial-rewards-recorded', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'trial-rewards-recorded'.</exception>
    public ChronicleLabs.TrialEventTrialRewardsRecorded AsTrialRewardsRecorded() =>
        IsTrialRewardsRecorded
            ? (ChronicleLabs.TrialEventTrialRewardsRecorded)Value!
            : throw new global::System.Exception("TrialEvent.Kind is not 'trial-rewards-recorded'");

    /// <summary>
    /// Returns the value as a <see cref="ChronicleLabs.TrialEventTrialFinished"/> if <see cref="Kind"/> is 'trial-finished', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'trial-finished'.</exception>
    public ChronicleLabs.TrialEventTrialFinished AsTrialFinished() =>
        IsTrialFinished
            ? (ChronicleLabs.TrialEventTrialFinished)Value!
            : throw new global::System.Exception("TrialEvent.Kind is not 'trial-finished'");

    /// <summary>
    /// Returns the value as a <see cref="ChronicleLabs.TrialEventJobFinished"/> if <see cref="Kind"/> is 'job-finished', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Kind"/> is not 'job-finished'.</exception>
    public ChronicleLabs.TrialEventJobFinished AsJobFinished() =>
        IsJobFinished
            ? (ChronicleLabs.TrialEventJobFinished)Value!
            : throw new global::System.Exception("TrialEvent.Kind is not 'job-finished'");

    public T Match<T>(
        Func<ChronicleLabs.TrialEventJobStarted, T> onJobStarted,
        Func<ChronicleLabs.TrialEventTrialPhaseChanged, T> onTrialPhaseChanged,
        Func<ChronicleLabs.TrialEventTrialRewardsRecorded, T> onTrialRewardsRecorded,
        Func<ChronicleLabs.TrialEventTrialFinished, T> onTrialFinished,
        Func<ChronicleLabs.TrialEventJobFinished, T> onJobFinished,
        Func<string, object?, T> onUnknown_
    )
    {
        return Kind switch
        {
            "job-started" => onJobStarted(AsJobStarted()),
            "trial-phase-changed" => onTrialPhaseChanged(AsTrialPhaseChanged()),
            "trial-rewards-recorded" => onTrialRewardsRecorded(AsTrialRewardsRecorded()),
            "trial-finished" => onTrialFinished(AsTrialFinished()),
            "job-finished" => onJobFinished(AsJobFinished()),
            _ => onUnknown_(Kind, Value),
        };
    }

    public void Visit(
        Action<ChronicleLabs.TrialEventJobStarted> onJobStarted,
        Action<ChronicleLabs.TrialEventTrialPhaseChanged> onTrialPhaseChanged,
        Action<ChronicleLabs.TrialEventTrialRewardsRecorded> onTrialRewardsRecorded,
        Action<ChronicleLabs.TrialEventTrialFinished> onTrialFinished,
        Action<ChronicleLabs.TrialEventJobFinished> onJobFinished,
        Action<string, object?> onUnknown_
    )
    {
        switch (Kind)
        {
            case "job-started":
                onJobStarted(AsJobStarted());
                break;
            case "trial-phase-changed":
                onTrialPhaseChanged(AsTrialPhaseChanged());
                break;
            case "trial-rewards-recorded":
                onTrialRewardsRecorded(AsTrialRewardsRecorded());
                break;
            case "trial-finished":
                onTrialFinished(AsTrialFinished());
                break;
            case "job-finished":
                onJobFinished(AsJobFinished());
                break;
            default:
                onUnknown_(Kind, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="ChronicleLabs.TrialEventJobStarted"/> and returns true if successful.
    /// </summary>
    public bool TryAsJobStarted(out ChronicleLabs.TrialEventJobStarted? value)
    {
        if (Kind == "job-started")
        {
            value = (ChronicleLabs.TrialEventJobStarted)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="ChronicleLabs.TrialEventTrialPhaseChanged"/> and returns true if successful.
    /// </summary>
    public bool TryAsTrialPhaseChanged(out ChronicleLabs.TrialEventTrialPhaseChanged? value)
    {
        if (Kind == "trial-phase-changed")
        {
            value = (ChronicleLabs.TrialEventTrialPhaseChanged)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="ChronicleLabs.TrialEventTrialRewardsRecorded"/> and returns true if successful.
    /// </summary>
    public bool TryAsTrialRewardsRecorded(out ChronicleLabs.TrialEventTrialRewardsRecorded? value)
    {
        if (Kind == "trial-rewards-recorded")
        {
            value = (ChronicleLabs.TrialEventTrialRewardsRecorded)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="ChronicleLabs.TrialEventTrialFinished"/> and returns true if successful.
    /// </summary>
    public bool TryAsTrialFinished(out ChronicleLabs.TrialEventTrialFinished? value)
    {
        if (Kind == "trial-finished")
        {
            value = (ChronicleLabs.TrialEventTrialFinished)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="ChronicleLabs.TrialEventJobFinished"/> and returns true if successful.
    /// </summary>
    public bool TryAsJobFinished(out ChronicleLabs.TrialEventJobFinished? value)
    {
        if (Kind == "job-finished")
        {
            value = (ChronicleLabs.TrialEventJobFinished)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator TrialEvent(TrialEvent.JobStarted value) => new(value);

    public static implicit operator TrialEvent(TrialEvent.TrialPhaseChanged value) => new(value);

    public static implicit operator TrialEvent(TrialEvent.TrialRewardsRecorded value) => new(value);

    public static implicit operator TrialEvent(TrialEvent.TrialFinished value) => new(value);

    public static implicit operator TrialEvent(TrialEvent.JobFinished value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<TrialEvent>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(TrialEvent).IsAssignableFrom(typeToConvert);

        public override TrialEvent Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("kind", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'kind'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'kind' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'kind' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'kind' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("kind");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "job-started" =>
                    jsonWithoutDiscriminator.Deserialize<ChronicleLabs.TrialEventJobStarted?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize ChronicleLabs.TrialEventJobStarted"
                        ),
                "trial-phase-changed" =>
                    jsonWithoutDiscriminator.Deserialize<ChronicleLabs.TrialEventTrialPhaseChanged?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize ChronicleLabs.TrialEventTrialPhaseChanged"
                        ),
                "trial-rewards-recorded" =>
                    jsonWithoutDiscriminator.Deserialize<ChronicleLabs.TrialEventTrialRewardsRecorded?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize ChronicleLabs.TrialEventTrialRewardsRecorded"
                        ),
                "trial-finished" =>
                    jsonWithoutDiscriminator.Deserialize<ChronicleLabs.TrialEventTrialFinished?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize ChronicleLabs.TrialEventTrialFinished"
                        ),
                "job-finished" =>
                    jsonWithoutDiscriminator.Deserialize<ChronicleLabs.TrialEventJobFinished?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize ChronicleLabs.TrialEventJobFinished"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new TrialEvent(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TrialEvent value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Kind switch
                {
                    "job-started" => JsonSerializer.SerializeToNode(value.Value, options),
                    "trial-phase-changed" => JsonSerializer.SerializeToNode(value.Value, options),
                    "trial-rewards-recorded" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "trial-finished" => JsonSerializer.SerializeToNode(value.Value, options),
                    "job-finished" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["kind"] = value.Kind;
            json.WriteTo(writer, options);
        }

        public override TrialEvent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new TrialEvent(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TrialEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Kind);
        }
    }

    /// <summary>
    /// Discriminated union type for job-started
    /// </summary>
    [Serializable]
    public struct JobStarted
    {
        public JobStarted(ChronicleLabs.TrialEventJobStarted value)
        {
            Value = value;
        }

        internal ChronicleLabs.TrialEventJobStarted Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TrialEvent.JobStarted(
            ChronicleLabs.TrialEventJobStarted value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for trial-phase-changed
    /// </summary>
    [Serializable]
    public struct TrialPhaseChanged
    {
        public TrialPhaseChanged(ChronicleLabs.TrialEventTrialPhaseChanged value)
        {
            Value = value;
        }

        internal ChronicleLabs.TrialEventTrialPhaseChanged Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TrialEvent.TrialPhaseChanged(
            ChronicleLabs.TrialEventTrialPhaseChanged value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for trial-rewards-recorded
    /// </summary>
    [Serializable]
    public struct TrialRewardsRecorded
    {
        public TrialRewardsRecorded(ChronicleLabs.TrialEventTrialRewardsRecorded value)
        {
            Value = value;
        }

        internal ChronicleLabs.TrialEventTrialRewardsRecorded Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TrialEvent.TrialRewardsRecorded(
            ChronicleLabs.TrialEventTrialRewardsRecorded value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for trial-finished
    /// </summary>
    [Serializable]
    public struct TrialFinished
    {
        public TrialFinished(ChronicleLabs.TrialEventTrialFinished value)
        {
            Value = value;
        }

        internal ChronicleLabs.TrialEventTrialFinished Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TrialEvent.TrialFinished(
            ChronicleLabs.TrialEventTrialFinished value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for job-finished
    /// </summary>
    [Serializable]
    public struct JobFinished
    {
        public JobFinished(ChronicleLabs.TrialEventJobFinished value)
        {
            Value = value;
        }

        internal ChronicleLabs.TrialEventJobFinished Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator TrialEvent.JobFinished(
            ChronicleLabs.TrialEventJobFinished value
        ) => new(value);
    }
}
