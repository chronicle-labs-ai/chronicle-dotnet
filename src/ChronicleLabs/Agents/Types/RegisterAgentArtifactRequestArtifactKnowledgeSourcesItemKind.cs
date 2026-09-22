using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind.RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKindSerializer)
)]
[Serializable]
public readonly record struct RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind
    : IStringEnum
{
    public static readonly RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind Vector =
        new(Values.Vector);

    public static readonly RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind Doc = new(
        Values.Doc
    );

    public static readonly RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind Table = new(
        Values.Table
    );

    public static readonly RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind Graph = new(
        Values.Graph
    );

    public RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind(string value)
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
    public static RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind FromCustom(
        string value
    )
    {
        return new RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind(value);
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
        RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind value
    ) => value.Value;

    public static explicit operator RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind(
        string value
    ) => new(value);

    internal class RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKindSerializer
        : JsonConverter<RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind>
    {
        public override RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind Read(
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
            return new RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind ReadAsPropertyName(
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
            return new RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RegisterAgentArtifactRequestArtifactKnowledgeSourcesItemKind value,
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
