namespace ChronicleLabs;

public partial interface ISearchClient
{
    /// <summary>
    /// Requires scope events:read or events:write. The page size is capped at 200 and a cursor can advance through at most 1,000 relevance-ranked results. Each request consumes 5 rate-limit units.
    /// </summary>
    WithRawResponseTask<EventListResponse> EventsAsync(
        SearchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
