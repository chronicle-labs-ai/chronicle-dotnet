namespace ChronicleLabs;

public partial interface IChronicle
{
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
