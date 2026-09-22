using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind.AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKindSerializer)
)]
[Serializable]
public readonly record struct AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind
    : IStringEnum
{
    public static readonly AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind Input = new(
        Values.Input
    );

    public static readonly AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind Tool = new(
        Values.Tool
    );

    public static readonly AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind Model = new(
        Values.Model
    );

    public static readonly AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind Branch =
        new(Values.Branch);

    public static readonly AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind Output =
        new(Values.Output);

    public AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind(string value)
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
    public static AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind FromCustom(
        string value
    )
    {
        return new AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind(value);
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
        AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind value
    ) => value.Value;

    public static explicit operator AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind(
        string value
    ) => new(value);

    internal class AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKindSerializer
        : JsonConverter<AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind>
    {
        public override AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind Read(
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
            return new AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind ReadAsPropertyName(
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
            return new AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentVersionSummaryArtifactWorkflowGraphPreviewNodesItemKind value,
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
