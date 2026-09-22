using ChronicleLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ChronicleLabs;

[JsonConverter(typeof(HashIndexEntryFramework.HashIndexEntryFrameworkSerializer))]
[Serializable]
public readonly record struct HashIndexEntryFramework : IStringEnum
{
    public static readonly HashIndexEntryFramework VercelAiSdk = new(Values.VercelAiSdk);

    public static readonly HashIndexEntryFramework OpenaiAgents = new(Values.OpenaiAgents);

    public static readonly HashIndexEntryFramework Langchain = new(Values.Langchain);

    public static readonly HashIndexEntryFramework Mastra = new(Values.Mastra);

    public static readonly HashIndexEntryFramework LangchainPython = new(Values.LangchainPython);

    public static readonly HashIndexEntryFramework Llamaindex = new(Values.Llamaindex);

    public static readonly HashIndexEntryFramework Crewai = new(Values.Crewai);

    public static readonly HashIndexEntryFramework Smolagents = new(Values.Smolagents);

    public static readonly HashIndexEntryFramework PydanticAi = new(Values.PydanticAi);

    public static readonly HashIndexEntryFramework Strands = new(Values.Strands);

    public static readonly HashIndexEntryFramework GoogleAdk = new(Values.GoogleAdk);

    public static readonly HashIndexEntryFramework OpenaiAgentsPython = new(
        Values.OpenaiAgentsPython
    );

    public static readonly HashIndexEntryFramework Autogen = new(Values.Autogen);

    public static readonly HashIndexEntryFramework Eve = new(Values.Eve);

    public static readonly HashIndexEntryFramework SalesforceAgentforce = new(
        Values.SalesforceAgentforce
    );

    public HashIndexEntryFramework(string value)
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
    public static HashIndexEntryFramework FromCustom(string value)
    {
        return new HashIndexEntryFramework(value);
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

    public static bool operator ==(HashIndexEntryFramework value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(HashIndexEntryFramework value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(HashIndexEntryFramework value) => value.Value;

    public static explicit operator HashIndexEntryFramework(string value) => new(value);

    internal class HashIndexEntryFrameworkSerializer : JsonConverter<HashIndexEntryFramework>
    {
        public override HashIndexEntryFramework Read(
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
            return new HashIndexEntryFramework(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            HashIndexEntryFramework value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override HashIndexEntryFramework ReadAsPropertyName(
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
            return new HashIndexEntryFramework(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            HashIndexEntryFramework value,
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
