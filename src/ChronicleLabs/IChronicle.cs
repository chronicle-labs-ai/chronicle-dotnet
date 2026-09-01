namespace ChronicleLabs;

public partial interface IChronicle
{
    public IEventsClient Events { get; }
    public ITimelineClient Timeline { get; }
    public ISearchClient Search { get; }
    public IDiscoverClient Discover { get; }
    public ILinksClient Links { get; }
    public ISdkClient Sdk { get; }
}
