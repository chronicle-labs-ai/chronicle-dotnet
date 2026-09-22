using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(AgentSnapshotHashIndexItemKind.AgentSnapshotHashIndexItemKindSerializer))]
[Serializable]
public readonly record struct AgentSnapshotHashIndexItemKind : IStringEnum
{
    public static readonly AgentSnapshotHashIndexItemKind AgentRoot = new(Values.AgentRoot);

    public static readonly AgentSnapshotHashIndexItemKind Prompt = new(Values.Prompt);

    public static readonly AgentSnapshotHashIndexItemKind ModelContract = new(Values.ModelContract);

    public static readonly AgentSnapshotHashIndexItemKind ProviderOptions = new(
        Values.ProviderOptions
    );

    public static readonly AgentSnapshotHashIndexItemKind ToolContract = new(Values.ToolContract);

    public static readonly AgentSnapshotHashIndexItemKind RuntimePolicy = new(Values.RuntimePolicy);

    public static readonly AgentSnapshotHashIndexItemKind Dependency = new(Values.Dependency);

    public static readonly AgentSnapshotHashIndexItemKind KnowledgeContract = new(
        Values.KnowledgeContract
    );

    public static readonly AgentSnapshotHashIndexItemKind WorkflowGraph = new(Values.WorkflowGraph);

    public static readonly AgentSnapshotHashIndexItemKind EffectiveRun = new(Values.EffectiveRun);

    public static readonly AgentSnapshotHashIndexItemKind ProviderObservation = new(
        Values.ProviderObservation
    );

    public static readonly AgentSnapshotHashIndexItemKind Operational = new(Values.Operational);

    public static readonly AgentSnapshotHashIndexItemKind Output = new(Values.Output);

    public AgentSnapshotHashIndexItemKind(string value)
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
    public static AgentSnapshotHashIndexItemKind FromCustom(string value)
    {
        return new AgentSnapshotHashIndexItemKind(value);
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

    public static bool operator ==(AgentSnapshotHashIndexItemKind value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentSnapshotHashIndexItemKind value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentSnapshotHashIndexItemKind value) => value.Value;

    public static explicit operator AgentSnapshotHashIndexItemKind(string value) => new(value);

    internal class AgentSnapshotHashIndexItemKindSerializer
        : JsonConverter<AgentSnapshotHashIndexItemKind>
    {
        public override AgentSnapshotHashIndexItemKind Read(
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
            return new AgentSnapshotHashIndexItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotHashIndexItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotHashIndexItemKind ReadAsPropertyName(
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
            return new AgentSnapshotHashIndexItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotHashIndexItemKind value,
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
