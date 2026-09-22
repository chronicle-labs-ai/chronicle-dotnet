namespace ChronicleLabs;

public partial interface IEnvironmentsClient
{
    WithRawResponseTask<ListEnvironmentsResponse> ListEnvironmentsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<EnvironmentResponse> CreateEnvironmentAsync(
        CreateEnvironmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<EnvironmentResponse> GetEnvironmentAsync(
        GetEnvironmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<EnvironmentVersionRecord>> ListEnvironmentVersionsAsync(
        ListEnvironmentVersionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<EnvironmentVersionResponse> CreateEnvironmentVersionAsync(
        CreateEnvironmentVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<EnvironmentVersionResponse> GetEnvironmentVersionAsync(
        GetEnvironmentVersionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CompileEnvironmentResponse> CompileEnvironmentVersionAsync(
        CompileEnvironmentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
