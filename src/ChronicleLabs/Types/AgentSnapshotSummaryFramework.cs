using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(AgentSnapshotSummaryFramework.AgentSnapshotSummaryFrameworkSerializer))]
[Serializable]
public readonly record struct AgentSnapshotSummaryFramework : IStringEnum
{
    public static readonly AgentSnapshotSummaryFramework VercelAiSdk = new(Values.VercelAiSdk);

    public static readonly AgentSnapshotSummaryFramework OpenaiAgents = new(Values.OpenaiAgents);

    public static readonly AgentSnapshotSummaryFramework Langchain = new(Values.Langchain);

    public static readonly AgentSnapshotSummaryFramework Mastra = new(Values.Mastra);

    public static readonly AgentSnapshotSummaryFramework LangchainPython = new(
        Values.LangchainPython
    );

    public static readonly AgentSnapshotSummaryFramework Llamaindex = new(Values.Llamaindex);

    public static readonly AgentSnapshotSummaryFramework Crewai = new(Values.Crewai);

    public static readonly AgentSnapshotSummaryFramework Smolagents = new(Values.Smolagents);

    public static readonly AgentSnapshotSummaryFramework PydanticAi = new(Values.PydanticAi);

    public static readonly AgentSnapshotSummaryFramework Strands = new(Values.Strands);

    public static readonly AgentSnapshotSummaryFramework GoogleAdk = new(Values.GoogleAdk);

    public static readonly AgentSnapshotSummaryFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly AgentSnapshotSummaryFramework Autogen = new(Values.Autogen);

    public static readonly AgentSnapshotSummaryFramework Eve = new(Values.Eve);

    public static readonly AgentSnapshotSummaryFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public AgentSnapshotSummaryFramework(string value)
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
    public static AgentSnapshotSummaryFramework FromCustom(string value)
    {
        return new AgentSnapshotSummaryFramework(value);
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

    public static bool operator ==(AgentSnapshotSummaryFramework value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentSnapshotSummaryFramework value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentSnapshotSummaryFramework value) => value.Value;

    public static explicit operator AgentSnapshotSummaryFramework(string value) => new(value);

    internal class AgentSnapshotSummaryFrameworkSerializer
        : JsonConverter<AgentSnapshotSummaryFramework>
    {
        public override AgentSnapshotSummaryFramework Read(
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
            return new AgentSnapshotSummaryFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotSummaryFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotSummaryFramework ReadAsPropertyName(
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
            return new AgentSnapshotSummaryFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotSummaryFramework value,
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
