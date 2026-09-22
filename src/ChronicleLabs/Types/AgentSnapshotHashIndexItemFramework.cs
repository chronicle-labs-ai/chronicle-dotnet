using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(AgentSnapshotHashIndexItemFramework.AgentSnapshotHashIndexItemFrameworkSerializer)
)]
[Serializable]
public readonly record struct AgentSnapshotHashIndexItemFramework : IStringEnum
{
    public static readonly AgentSnapshotHashIndexItemFramework VercelAiSdk = new(
        Values.VercelAiSdk
    );

    public static readonly AgentSnapshotHashIndexItemFramework OpenaiAgents = new(
        Values.OpenaiAgents
    );

    public static readonly AgentSnapshotHashIndexItemFramework Langchain = new(Values.Langchain);

    public static readonly AgentSnapshotHashIndexItemFramework Mastra = new(Values.Mastra);

    public static readonly AgentSnapshotHashIndexItemFramework LangchainPython = new(
        Values.LangchainPython
    );

    public static readonly AgentSnapshotHashIndexItemFramework Llamaindex = new(Values.Llamaindex);

    public static readonly AgentSnapshotHashIndexItemFramework Crewai = new(Values.Crewai);

    public static readonly AgentSnapshotHashIndexItemFramework Smolagents = new(Values.Smolagents);

    public static readonly AgentSnapshotHashIndexItemFramework PydanticAi = new(Values.PydanticAi);

    public static readonly AgentSnapshotHashIndexItemFramework Strands = new(Values.Strands);

    public static readonly AgentSnapshotHashIndexItemFramework GoogleAdk = new(Values.GoogleAdk);

    public static readonly AgentSnapshotHashIndexItemFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly AgentSnapshotHashIndexItemFramework Autogen = new(Values.Autogen);

    public static readonly AgentSnapshotHashIndexItemFramework Eve = new(Values.Eve);

    public static readonly AgentSnapshotHashIndexItemFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public AgentSnapshotHashIndexItemFramework(string value)
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
    public static AgentSnapshotHashIndexItemFramework FromCustom(string value)
    {
        return new AgentSnapshotHashIndexItemFramework(value);
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

    public static bool operator ==(AgentSnapshotHashIndexItemFramework value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentSnapshotHashIndexItemFramework value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentSnapshotHashIndexItemFramework value) =>
        value.Value;

    public static explicit operator AgentSnapshotHashIndexItemFramework(string value) => new(value);

    internal class AgentSnapshotHashIndexItemFrameworkSerializer
        : JsonConverter<AgentSnapshotHashIndexItemFramework>
    {
        public override AgentSnapshotHashIndexItemFramework Read(
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
            return new AgentSnapshotHashIndexItemFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AgentSnapshotHashIndexItemFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AgentSnapshotHashIndexItemFramework ReadAsPropertyName(
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
            return new AgentSnapshotHashIndexItemFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AgentSnapshotHashIndexItemFramework value,
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
