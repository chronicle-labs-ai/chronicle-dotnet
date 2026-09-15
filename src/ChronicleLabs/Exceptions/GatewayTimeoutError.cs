namespace ChronicleLabs;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class GatewayTimeoutError(ErrorResponse body, ChronicleLabs.RawResponse? rawResponse = null)
    : ChronicleApiException("GatewayTimeoutError", 504, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorResponse Body => body;
}
