namespace Gasolutions.Core.ResultPattern.Tests;

/// <summary>
/// Test suite for <see cref="CommunicationErrors"/> factory class.
/// </summary>
public class CommunicationErrorsTests
{
    /// <summary>
    /// Verifies that CommunicationError returns the expected error code.
    /// </summary>
    [Fact]
    public void CommunicationError_ReturnsExpectedCode()
    {
        Error e = CommunicationErrors.CommunicationError("PaymentAPI", "Connection timeout");
        Assert.Equal("CommunicationErrors.CommunicationError", e.Code);
    }

    /// <summary>
    /// Verifies that CommunicationError includes the service name and error message.
    /// </summary>
    [Fact]
    public void CommunicationError_IncludesServiceName()
    {
        Error e = CommunicationErrors.CommunicationError("AuthService", "Unauthorized access");
        Assert.Contains("AuthService", e.Description);
        Assert.Contains("Unauthorized access", e.Description);
    }

    /// <summary>
    /// Verifies that CommunicationError includes caller class and method information.
    /// </summary>
    [Fact]
    public void CommunicationError_IncludesCallerContext()
    {
        Error e = CommunicationErrors.CommunicationError("EmailService", "SMTP error");
        Assert.Contains("CommunicationErrorsTests", e.Description);
        Assert.Contains("CommunicationError_IncludesCallerContext", e.Description);
    }

    /// <summary>
    /// Verifies that CommunicationError handles multiple different services correctly.
    /// </summary>
    [Fact]
    public void CommunicationError_WithVariousServices()
    {
        Error paymentError = CommunicationErrors.CommunicationError("PaymentAPI", "Gateway unavailable");
        Error authError = CommunicationErrors.CommunicationError("IdentityServer", "Service down");
        Error dbError = CommunicationErrors.CommunicationError("DatabaseService", "Connection refused");

        Assert.Contains("PaymentAPI", paymentError.Description);
        Assert.Contains("IdentityServer", authError.Description);
        Assert.Contains("DatabaseService", dbError.Description);
    }
}