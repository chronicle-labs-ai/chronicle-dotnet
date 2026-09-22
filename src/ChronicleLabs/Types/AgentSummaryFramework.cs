using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(AgentSummaryFramework.AgentSummaryFrameworkSerializer))]
[Serializable]
public readonly record struct AgentSummaryFramework : IStringEnum
{
    public static readonly AgentSummaryFramework VercelAiSdk = new(Values.VercelAiSdk);

    public static readonly AgentSummaryFramework OpenaiAgents = new(Values.OpenaiAgents);

    public static readonly AgentSummaryFramework Langchain = new(Values.Langchain);

    public static readonly AgentSummaryFramework Mastra = new(Values.Mastra);

    public static readonly AgentSummaryFramework LangchainPython = new(Values.LangchainPython);

    public static readonly AgentSummaryFramework Llamaindex = new(Values.Llamaindex);

    public static readonly AgentSummaryFramework Crewai = new(Values.Crewai);

    public static readonly AgentSummaryFramework Smolagents = new(Values.Smolagents);

    public static readonly AgentSummaryFramework PydanticAi = new(Values.PydanticAi);

    public static readonly AgentSummaryFramework Strands = new(Values.Strands);

    public static readonly AgentSummaryFramework GoogleAdk = new(Values.GoogleAdk);

    public static readonly AgentSummaryFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly AgentSummaryFramework Autogen = new(Values.Autogen);

    public static readonly AgentSummaryFramework Eve = new(Values.Eve);

    public static readonly AgentSummaryFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public AgentSummaryFramework(string value)
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
    public static AgentSummaryFramework FromCustom(string value)
    {
        return new AgentSummaryFramework(value);
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

    public static bool operator ==(AgentSummaryFramework value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentSummaryFramework value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentSummaryFramework value) => value.Value;

    public static explicit operator AgentSummaryFramework(string value) => new(value);

    internal class AgentSummaryFrameworkSerializer : JsonConverter<AgentSummaryFramework>
    {
        public override AgentSummaryFramework Read(
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
            return new AgentSummaryFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSummaryFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSummaryFramework ReadAsPropertyName(
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
            return new AgentSummaryFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSummaryFramework value,
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
