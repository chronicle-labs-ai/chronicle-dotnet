namespace ChronicleLabs;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class ChronicleException(string message, Exception? innerException = null)
    : Exception(message, innerException);
