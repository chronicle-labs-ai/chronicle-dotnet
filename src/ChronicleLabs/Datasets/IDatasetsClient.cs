namespace ChronicleLabs;

public partial interface IDatasetsClient
{
    WithRawResponseTask<TaskSuitePage> ListDatasetsAsync(
        ListDatasetsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskSuite> CreateDatasetAsync(
        CreateTaskSuitePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateTaskSuiteWithTraceResponse> CreateDatasetWithTraceAsync(
        CreateTaskSuiteWithTraceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskSuiteDetail> GetDatasetAsync(
        GetDatasetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask ArchiveDatasetAsync(
        ArchiveDatasetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskSuite> UpdateDatasetAsync(
        TaskSuitePatch request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskSuiteSnapshot> GetDatasetSnapshotAsync(
        GetDatasetSnapshotRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskPage> ListDatasetTracesAsync(
        ListDatasetTracesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AddTaskFromTraceResponse> AddTraceToDatasetAsync(
        AddTaskFromTraceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask UpdateDatasetTracesAsync(
        UpdateTracesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask RemoveTraceFromDatasetAsync(
        RemoveTraceFromDatasetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskMembership> RefreshDatasetTraceAsync(
        RefreshDatasetTraceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskEventPage> ListDatasetTraceEventsAsync(
        ListDatasetTraceEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<TaskMembership>> ListTraceDatasetMembershipsAsync(
        ListTraceDatasetMembershipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskPage> ListDatasetTasksAsync(
        ListDatasetTasksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Task> CreateDatasetTaskAsync(
        CreateDatasetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Task> GetDatasetTaskAsync(
        GetDatasetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask DeleteDatasetTaskAsync(
        DeleteDatasetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Task> UpdateDatasetTaskAsync(
        UpdateDatasetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Task> SetDatasetTaskVerifiersAsync(
        SetTaskVerifiersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskEventPage> ListDatasetTaskEventsAsync(
        ListDatasetTaskEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskMembership> RefreshDatasetTaskAsync(
        RefreshDatasetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<DatasetCluster>> ListDatasetClustersAsync(
        ListDatasetClustersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DatasetCluster> CreateDatasetClusterAsync(
        CreateClusterRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask DeleteDatasetClusterAsync(
        DeleteDatasetClusterRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DatasetCluster> UpdateDatasetClusterAsync(
        UpdateClusterRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<DatasetSavedView>> ListDatasetSavedViewsAsync(
        ListDatasetSavedViewsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DatasetSavedView> CreateDatasetSavedViewAsync(
        CreateSavedViewRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask DeleteDatasetSavedViewAsync(
        DeleteDatasetSavedViewRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<DatasetSavedView> UpdateDatasetSavedViewAsync(
        DatasetSavedViewPatch request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<TaskSuiteVersion>> ListDatasetVersionsAsync(
        ListDatasetVersionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskSuiteVersion> PublishDatasetVersionAsync(
        PublishVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<TaskSuiteSnapshot> GetDatasetVersionAsync(
        GetDatasetVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<TaskSuiteEvalRun>> ListDatasetEvaluationRunsAsync(
        ListDatasetEvaluationRunsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
