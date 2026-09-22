using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(
    typeof(BacktestsAvailabilityAgentsItemFramework.BacktestsAvailabilityAgentsItemFrameworkSerializer)
)]
[Serializable]
public readonly record struct BacktestsAvailabilityAgentsItemFramework : IStringEnum
{
    public static readonly BacktestsAvailabilityAgentsItemFramework VercelAiSdk = new(
        Values.VercelAiSdk
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework OpenaiAgents = new(
        Values.OpenaiAgents
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework Langchain = new(
        Values.Langchain
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework Mastra = new(Values.Mastra);

    public static readonly BacktestsAvailabilityAgentsItemFramework LangchainPython = new(
        Values.LangchainPython
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework Llamaindex = new(
        Values.Llamaindex
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework Crewai = new(Values.Crewai);

    public static readonly BacktestsAvailabilityAgentsItemFramework Smolagents = new(
        Values.Smolagents
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework PydanticAi = new(
        Values.PydanticAi
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework Strands = new(Values.Strands);

    public static readonly BacktestsAvailabilityAgentsItemFramework GoogleAdk = new(
        Values.GoogleAdk
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly BacktestsAvailabilityAgentsItemFramework Autogen = new(Values.Autogen);

    public static readonly BacktestsAvailabilityAgentsItemFramework Eve = new(Values.Eve);

    public static readonly BacktestsAvailabilityAgentsItemFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public BacktestsAvailabilityAgentsItemFramework(string value)
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
    public static BacktestsAvailabilityAgentsItemFramework FromCustom(string value)
    {
        return new BacktestsAvailabilityAgentsItemFramework(value);
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
        BacktestsAvailabilityAgentsItemFramework value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BacktestsAvailabilityAgentsItemFramework value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BacktestsAvailabilityAgentsItemFramework value) =>
        value.Value;

    public static explicit operator BacktestsAvailabilityAgentsItemFramework(string value) =>
        new(value);

    internal class BacktestsAvailabilityAgentsItemFrameworkSerializer
        : JsonConverter<BacktestsAvailabilityAgentsItemFramework>
    {
        public override BacktestsAvailabilityAgentsItemFramework Read(
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
            return new BacktestsAvailabilityAgentsItemFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BacktestsAvailabilityAgentsItemFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BacktestsAvailabilityAgentsItemFramework ReadAsPropertyName(
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
            return new BacktestsAvailabilityAgentsItemFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BacktestsAvailabilityAgentsItemFramework value,
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
