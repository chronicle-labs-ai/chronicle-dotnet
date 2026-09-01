namespace ChronicleLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(
    ErrorResponse body,
    ChronicleLabs.RawResponse? rawResponse = null
) : ChronicleApiException("ServiceUnavailableError", 503, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponse Body => body;
}
