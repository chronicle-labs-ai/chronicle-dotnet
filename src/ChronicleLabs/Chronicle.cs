using ChronicleLabs.Core;

namespace ChronicleLabs;

public partial class Chronicle : IChronicle
{
    private readonly RawClient _client;

    public Chronicle(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "ChronicleLabs.Api" },
                { "X-Fern-SDK-Version", global::ChronicleLabs.Version.Current },
                { "User-Agent", "ChronicleLabs.Api/0.0.14" },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Events = new EventsClient(_client);
        Timeline = new TimelineClient(_client);
        Search = new SearchClient(_client);
        Discover = new DiscoverClient(_client);
        Links = new LinksClient(_client);
        Sdk = new SdkClient(_client);
        Agents = new AgentsClient(_client);
        Datasets = new DatasetsClient(_client);
        Environments = new EnvironmentsClient(_client);
        Backtests = new BacktestsClient(_client);
        Credentials = new CredentialsClient(_client);
    }

    public IEventsClient Events { get; }

    public ITimelineClient Timeline { get; }

    public ISearchClient Search { get; }

    public IDiscoverClient Discover { get; }

    public ILinksClient Links { get; }

    public ISdkClient Sdk { get; }

    public IAgentsClient Agents { get; }

    public IDatasetsClient Datasets { get; }

    public IEnvironmentsClient Environments { get; }

    public IBacktestsClient Backtests { get; }

    public ICredentialsClient Credentials { get; }
}
