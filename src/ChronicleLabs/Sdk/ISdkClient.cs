namespace ChronicleLabs;

public partial interface ISdkClient
{
    /// <summary>
    /// Requires scope users:write.
    /// </summary>
    WithRawResponseTask<AcceptedResponse> IdentifyUserAsync(
        IdentifyUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope signals:write. Maximum 1000 signals per request; larger batches are rejected with 422. Each request consumes 10 rate-limit units.
    /// </summary>
    WithRawResponseTask<AcceptedResponse> TrackSignalsAsync(
        TrackSignalsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope traces:write. Maximum 1000 traces or total spans per request; larger batches are rejected with 422. Each request consumes 10 rate-limit units.
    /// </summary>
    WithRawResponseTask<AcceptedResponse> TrackTracesAsync(
        TrackTracesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
