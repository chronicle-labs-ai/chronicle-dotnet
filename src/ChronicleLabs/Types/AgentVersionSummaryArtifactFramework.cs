using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentVersionSummaryArtifactFramework.AgentVersionSummaryArtifactFrameworkSerializer)
)]
[Serializable]
public readonly record struct AgentVersionSummaryArtifactFramework : IStringEnum
{
    public static readonly AgentVersionSummaryArtifactFramework VercelAiSdk = new(
        Values.VercelAiSdk
    );

    public static readonly AgentVersionSummaryArtifactFramework OpenaiAgents = new(
        Values.OpenaiAgents
    );

    public static readonly AgentVersionSummaryArtifactFramework Langchain = new(Values.Langchain);

    public static readonly AgentVersionSummaryArtifactFramework Mastra = new(Values.Mastra);

    public static readonly AgentVersionSummaryArtifactFramework LangchainPython = new(
        Values.LangchainPython
    );

    public static readonly AgentVersionSummaryArtifactFramework Llamaindex = new(Values.Llamaindex);

    public static readonly AgentVersionSummaryArtifactFramework Crewai = new(Values.Crewai);

    public static readonly AgentVersionSummaryArtifactFramework Smolagents = new(Values.Smolagents);

    public static readonly AgentVersionSummaryArtifactFramework PydanticAi = new(Values.PydanticAi);

    public static readonly AgentVersionSummaryArtifactFramework Strands = new(Values.Strands);

    public static readonly AgentVersionSummaryArtifactFramework GoogleAdk = new(Values.GoogleAdk);

    public static readonly AgentVersionSummaryArtifactFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly AgentVersionSummaryArtifactFramework Autogen = new(Values.Autogen);

    public static readonly AgentVersionSummaryArtifactFramework Eve = new(Values.Eve);

    public static readonly AgentVersionSummaryArtifactFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public AgentVersionSummaryArtifactFramework(string value)
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
    public static AgentVersionSummaryArtifactFramework FromCustom(string value)
    {
        return new AgentVersionSummaryArtifactFramework(value);
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

    public static bool operator ==(AgentVersionSummaryArtifactFramework value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentVersionSummaryArtifactFramework value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentVersionSummaryArtifactFramework value) =>
        value.Value;

    public static explicit operator AgentVersionSummaryArtifactFramework(string value) =>
        new(value);

    internal class AgentVersionSummaryArtifactFrameworkSerializer
        : JsonConverter<AgentVersionSummaryArtifactFramework>
    {
        public override AgentVersionSummaryArtifactFramework Read(
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
            return new AgentVersionSummaryArtifactFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentVersionSummaryArtifactFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentVersionSummaryArtifactFramework ReadAsPropertyName(
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
            return new AgentVersionSummaryArtifactFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentVersionSummaryArtifactFramework value,
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
