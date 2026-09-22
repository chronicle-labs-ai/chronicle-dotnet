using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind.AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKindSerializer)
)]
[Serializable]
public readonly record struct AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind
    : IStringEnum
{
    public static readonly AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind Input =
        new(Values.Input);

    public static readonly AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind Tool =
        new(Values.Tool);

    public static readonly AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind Model =
        new(Values.Model);

    public static readonly AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind Branch =
        new(Values.Branch);

    public static readonly AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind Output =
        new(Values.Output);

    public AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind(string value)
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
    public static AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind FromCustom(
        string value
    )
    {
        return new AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind(value);
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
        AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind value
    ) => value.Value;

    public static explicit operator AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind(
        string value
    ) => new(value);

    internal class AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKindSerializer
        : JsonConverter<AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind>
    {
        public override AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind Read(
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
            return new AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind ReadAsPropertyName(
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
            return new AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemArtifactWorkflowGraphPreviewNodesItemKind value,
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
        public const string Input = "input";

        public const string Tool = "tool";

        public const string Model = "model";

        public const string Branch = "branch";

        public const string Output = "output";
    }
}
