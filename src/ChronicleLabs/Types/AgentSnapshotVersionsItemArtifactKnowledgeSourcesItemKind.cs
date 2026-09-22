using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind.AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKindSerializer)
)]
[Serializable]
public readonly record struct AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind
    : IStringEnum
{
    public static readonly AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind Vector = new(
        Values.Vector
    );

    public static readonly AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind Doc = new(
        Values.Doc
    );

    public static readonly AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind Table = new(
        Values.Table
    );

    public static readonly AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind Graph = new(
        Values.Graph
    );

    public AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind(string value)
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
    public static AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind FromCustom(string value)
    {
        return new AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind(value);
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
        AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind value
    ) => value.Value;

    public static explicit operator AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind(
        string value
    ) => new(value);

    internal class AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKindSerializer
        : JsonConverter<AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind>
    {
        public override AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind Read(
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
            return new AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind ReadAsPropertyName(
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
            return new AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemArtifactKnowledgeSourcesItemKind value,
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
