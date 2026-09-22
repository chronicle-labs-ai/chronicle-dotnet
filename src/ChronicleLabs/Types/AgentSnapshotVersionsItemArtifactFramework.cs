using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentSnapshotVersionsItemArtifactFramework.AgentSnapshotVersionsItemArtifactFrameworkSerializer)
)]
[Serializable]
public readonly record struct AgentSnapshotVersionsItemArtifactFramework : IStringEnum
{
    public static readonly AgentSnapshotVersionsItemArtifactFramework VercelAiSdk = new(
        Values.VercelAiSdk
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework OpenaiAgents = new(
        Values.OpenaiAgents
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework Langchain = new(
        Values.Langchain
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework Mastra = new(Values.Mastra);

    public static readonly AgentSnapshotVersionsItemArtifactFramework LangchainPython = new(
        Values.LangchainPython
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework Llamaindex = new(
        Values.Llamaindex
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework Crewai = new(Values.Crewai);

    public static readonly AgentSnapshotVersionsItemArtifactFramework Smolagents = new(
        Values.Smolagents
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework PydanticAi = new(
        Values.PydanticAi
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework Strands = new(Values.Strands);

    public static readonly AgentSnapshotVersionsItemArtifactFramework GoogleAdk = new(
        Values.GoogleAdk
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly AgentSnapshotVersionsItemArtifactFramework Autogen = new(Values.Autogen);

    public static readonly AgentSnapshotVersionsItemArtifactFramework Eve = new(Values.Eve);

    public static readonly AgentSnapshotVersionsItemArtifactFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public AgentSnapshotVersionsItemArtifactFramework(string value)
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
    public static AgentSnapshotVersionsItemArtifactFramework FromCustom(string value)
    {
        return new AgentSnapshotVersionsItemArtifactFramework(value);
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
        AgentSnapshotVersionsItemArtifactFramework value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        AgentSnapshotVersionsItemArtifactFramework value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(AgentSnapshotVersionsItemArtifactFramework value) =>
        value.Value;

    public static explicit operator AgentSnapshotVersionsItemArtifactFramework(string value) =>
        new(value);

    internal class AgentSnapshotVersionsItemArtifactFrameworkSerializer
        : JsonConverter<AgentSnapshotVersionsItemArtifactFramework>
    {
        public override AgentSnapshotVersionsItemArtifactFramework Read(
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
            return new AgentSnapshotVersionsItemArtifactFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemArtifactFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotVersionsItemArtifactFramework ReadAsPropertyName(
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
            return new AgentSnapshotVersionsItemArtifactFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotVersionsItemArtifactFramework value,
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
        public const string VercelAiSdk = "vercel-ai-sdk";

        public const string OpenaiAgents = "openai-agents";

        public const string Langchain = "langchain";

        public const string Mastra = "mastra";

        public const string LangchainPython = "langchain-python";

        public const string Llamaindex = "llamaindex";

        public const string Crewai = "crewai";

        public const string Smolagents = "smolagents";

        public const string PydanticAi = "pydantic-ai";

        public const string Strands = "strands";

        public const string GoogleAdk = "google-adk";

        public const string OpenaiAgentsPython = "openai-agents-python";

        public const string Autogen = "autogen";

        public const string Eve = "eve";

        public const string SalesforceAgentforce = "salesforce-agentforce";
    }
}
