namespace ChronicleLabs;

public partial interface ICredentialsClient
{
    WithRawResponseTask<SdkKeyListResponse> ListSdkKeysAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The bearer secret is returned once and is not stored in plaintext.
    /// </summary>
    WithRawResponseTask<CreatedSdkKey> CreateSdkKeyAsync(
        CreateSdkKeyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask RevokeSdkKeyAsync(
        RevokeSdkKeyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
