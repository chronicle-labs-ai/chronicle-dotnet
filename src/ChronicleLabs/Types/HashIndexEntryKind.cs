using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(HashIndexEntryKind.HashIndexEntryKindSerializer))]
[Serializable]
public readonly record struct HashIndexEntryKind : IStringEnum
{
    public static readonly HashIndexEntryKind AgentRoot = new(Values.AgentRoot);

    public static readonly HashIndexEntryKind Prompt = new(Values.Prompt);

    public static readonly HashIndexEntryKind ModelContract = new(Values.ModelContract);

    public static readonly HashIndexEntryKind ProviderOptions = new(Values.ProviderOptions);

    public static readonly HashIndexEntryKind ToolContract = new(Values.ToolContract);

    public static readonly HashIndexEntryKind RuntimePolicy = new(Values.RuntimePolicy);

    public static readonly HashIndexEntryKind Dependency = new(Values.Dependency);

    public static readonly HashIndexEntryKind KnowledgeContract = new(Values.KnowledgeContract);

    public static readonly HashIndexEntryKind WorkflowGraph = new(Values.WorkflowGraph);

    public static readonly HashIndexEntryKind EffectiveRun = new(Values.EffectiveRun);

    public static readonly HashIndexEntryKind ProviderObservation = new(Values.ProviderObservation);

    public static readonly HashIndexEntryKind Operational = new(Values.Operational);

    public static readonly HashIndexEntryKind Output = new(Values.Output);

    public HashIndexEntryKind(string value)
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
    public static HashIndexEntryKind FromCustom(string value)
    {
        return new HashIndexEntryKind(value);
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

    public static bool operator ==(HashIndexEntryKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(HashIndexEntryKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(HashIndexEntryKind value) => value.Value;

    public static explicit operator HashIndexEntryKind(string value) => new(value);

    internal class HashIndexEntryKindSerializer : JsonConverter<HashIndexEntryKind>
    {
        public override HashIndexEntryKind Read(
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
            return new HashIndexEntryKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            HashIndexEntryKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override HashIndexEntryKind ReadAsPropertyName(
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
            return new HashIndexEntryKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            HashIndexEntryKind value,
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
        public const string AgentRoot = "agent.root";

        public const string Prompt = "prompt";

        public const string ModelContract = "model.contract";

        public const string ProviderOptions = "provider.options";

        public const string ToolContract = "tool.contract";

        public const string RuntimePolicy = "runtime.policy";

        public const string Dependency = "dependency";

        public const string KnowledgeContract = "knowledge.contract";

        public const string WorkflowGraph = "workflow.graph";

        public const string EffectiveRun = "effective.run";

        public const string ProviderObservation = "provider.observation";

        public const string Operational = "operational";

        public const string Output = "output";
    }
}
