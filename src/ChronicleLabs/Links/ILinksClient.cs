namespace ChronicleLabs;

public partial interface ILinksClient
{
    /// <summary>
    /// Requires scope events:write.
    /// </summary>
    WithRawResponseTask<StatusResponse> AddEntityRefAsync(
        AddEntityRefRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:write.
    /// </summary>
    WithRawResponseTask<CreateLinkResponse> CreateEventLinkAsync(
        CreateLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:write.
    /// </summary>
    WithRawResponseTask<LinkEntityResponse> LinkEntitiesAsync(
        LinkEntityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:read or events:write. The traversal is bounded by `max_depth`, is not cursor-paginated, and consumes 5 rate-limit units.
    /// </summary>
    WithRawResponseTask<EventListResponse> TraverseGraphAsync(
        GraphRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
