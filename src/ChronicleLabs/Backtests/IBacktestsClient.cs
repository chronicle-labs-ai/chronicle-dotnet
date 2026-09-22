namespace ChronicleLabs;

public partial interface IBacktestsClient
{
    WithRawResponseTask<BacktestsAvailability> GetBacktestsAvailabilityAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ListBacktestJobsResponse> ListBacktestJobsAsync(
        ListBacktestJobsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns 202 after the durable job and its trials have been admitted.
    /// </summary>
    WithRawResponseTask<CreateBacktestJobResponse> CreateBacktestJobAsync(
        CreateBacktestJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<BacktestJobDetailResponse> GetBacktestJobAsync(
        GetBacktestJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ListBacktestJobTrialsResponse> ListBacktestJobTrialsAsync(
        ListBacktestJobTrialsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<BacktestTrialDetailResponse> GetBacktestTrialAsync(
        GetBacktestTrialRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CancelBacktestJobResponse> CancelBacktestJobAsync(
        CancelBacktestJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseStream<TrialEvent> StreamBacktestJobEventsAsync(
        StreamBacktestJobEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
