using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentVersionSummaryArtifactKnowledgeSourcesItemKind.AgentVersionSummaryArtifactKnowledgeSourcesItemKindSerializer)
)]
[Serializable]
public readonly record struct AgentVersionSummaryArtifactKnowledgeSourcesItemKind : IStringEnum
{
    public static readonly AgentVersionSummaryArtifactKnowledgeSourcesItemKind Vector = new(
        Values.Vector
    );

    public static readonly AgentVersionSummaryArtifactKnowledgeSourcesItemKind Doc = new(
        Values.Doc
    );

    public static readonly AgentVersionSummaryArtifactKnowledgeSourcesItemKind Table = new(
        Values.Table
    );

    public static readonly AgentVersionSummaryArtifactKnowledgeSourcesItemKind Graph = new(
        Values.Graph
    );

    public AgentVersionSummaryArtifactKnowledgeSourcesItemKind(string value)
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
    public static AgentVersionSummaryArtifactKnowledgeSourcesItemKind FromCustom(string value)
    {
        return new AgentVersionSummaryArtifactKnowledgeSourcesItemKind(value);
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
        AgentVersionSummaryArtifactKnowledgeSourcesItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentVersionSummaryArtifactKnowledgeSourcesItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AgentVersionSummaryArtifactKnowledgeSourcesItemKind value
    ) => value.Value;

    public static explicit operator AgentVersionSummaryArtifactKnowledgeSourcesItemKind(
        string value
    ) => new(value);

    internal class AgentVersionSummaryArtifactKnowledgeSourcesItemKindSerializer
        : JsonConverter<AgentVersionSummaryArtifactKnowledgeSourcesItemKind>
    {
        public override AgentVersionSummaryArtifactKnowledgeSourcesItemKind Read(
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
            return new AgentVersionSummaryArtifactKnowledgeSourcesItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentVersionSummaryArtifactKnowledgeSourcesItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentVersionSummaryArtifactKnowledgeSourcesItemKind ReadAsPropertyName(
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
            return new AgentVersionSummaryArtifactKnowledgeSourcesItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentVersionSummaryArtifactKnowledgeSourcesItemKind value,
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
        public const string Vector = "vector";

        public const string Doc = "doc";

        public const string Table = "table";

        public const string Graph = "graph";
    }
}
