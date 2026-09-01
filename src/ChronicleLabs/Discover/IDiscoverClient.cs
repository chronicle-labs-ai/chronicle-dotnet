namespace ChronicleLabs;

public partial interface IDiscoverClient
{
    /// <summary>
    /// Requires scope events:read or events:write. Returns the complete source metadata set without pagination.
    /// </summary>
    WithRawResponseTask<SourceListResponse> ListSourcesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:read or events:write. Returns the complete entity-type metadata set without pagination.
    /// </summary>
    WithRawResponseTask<EntityTypeListResponse> ListEntityTypesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:read or events:write. Entities are ordered by event count and entity ID. The limit is capped at 200; pass `next_cursor` as `cursor`.
    /// </summary>
    WithRawResponseTask<EntityListResponse> ListEntitiesAsync(
        ListEntitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:read or events:write.
    /// </summary>
    WithRawResponseTask<SourceSchema> GetEventSchemaAsync(
        GetEventSchemaRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
