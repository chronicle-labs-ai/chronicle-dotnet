namespace ChronicleLabs;

public partial interface IEventsClient
{
    /// <summary>
    /// Requires scope events:read or events:write. Results are scoped to the tenant of the API key and ordered newest first by event time and event ID. Pass the opaque `next_cursor` as `cursor` to continue without an offset scan.
    /// </summary>
    WithRawResponseTask<EventListResponse> QueryEventsAsync(
        QueryEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:write.
    /// </summary>
    WithRawResponseTask<IngestResponse> IngestEventAsync(
        IngestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:write. Maximum 1000 events per batch; larger batches are rejected with 422. Request bodies over the size limit are rejected with 413. Each request consumes 10 rate-limit units.
    /// </summary>
    WithRawResponseTask<IngestResponse> IngestEventBatchAsync(
        IEnumerable<IngestRequest> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope events:read or events:write. A Server-Sent Events stream of events matching the optional filters, held open indefinitely.
    ///
    /// Opening a stream consumes 5 rate-limit units.
    ///
    /// Each message has `event: event` and a `data` field carrying one EventResult as JSON. A comment line arrives every 15 seconds so intermediaries do not close an idle connection.
    ///
    /// Every message carries an opaque, stream-specific `id` backed by a monotonic per-tenant delivery sequence. It records ingestion order, independently of the source event's `event_time`. Record the last id you processed and do not parse or construct it.
    ///
    /// When `Last-Event-ID` is present, the server first establishes the live subscription, replays matching stored events strictly after that position in ascending order, and then continues with live delivery. Events committed at the history-to-live boundary may be delivered more than once, so consumers should deduplicate by `event_id`. This provides at-least-once delivery across a reconnect without leaving a gap.
    ///
    /// Replay is limited to 1000 matching events. An older position returns 409 before the stream opens. Slow consumers are disconnected when the bounded live buffer fills and should reconnect with their last processed id. Concurrent streams are limited per tenant and may return 429 with `Retry-After`.
    /// </summary>
    WithRawResponseStream<EventResult> StreamEventsAsync(
        StreamEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
