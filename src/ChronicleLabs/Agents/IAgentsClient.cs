namespace ChronicleLabs;

public partial interface IAgentsClient
{
    WithRawResponseTask<IEnumerable<AgentSummary>> ListAgentsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<HashIndexEntry>> SearchAgentHashIndexAsync(
        SearchAgentHashIndexRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseStream<Dictionary<string, object?>> SubscribeToAgentChangesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgentSummary> UpdateAgentAsync(
        UpdateAgentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgentSnapshot?> GetAgentSnapshotAsync(
        GetAgentSnapshotRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgentSummary> PinLatestAgentVersionAsync(
        PinLatestAgentVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateAgentChatSessionResponse> CreateAgentChatSessionAsync(
        CreateAgentChatSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<AgentChatSession> GetAgentChatSessionAsync(
        GetAgentChatSessionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<SendAgentChatMessageResponse> SendAgentChatMessageAsync(
        SendAgentChatMessageRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope agents:write.
    /// </summary>
    WithRawResponseTask<AgentVersionSummary> RegisterAgentArtifactAsync(
        RegisterAgentArtifactRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Requires scope agents:write.
    /// </summary>
    WithRawResponseTask<RecordAgentRunsResponse> RecordAgentRunsAsync(
        RecordAgentRunsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
