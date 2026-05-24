namespace Gasolutions.Core.Patterns.Result.Tests;

public class AuthErrorsTests
{
    [Fact]
    public void UserBlocked_WithUserName_ReturnsErrorWithUserNameInDescription()
    {
        Error e = AuthErrors.UserBlocked("testuser");
        Assert.Contains("testuser", e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("UserBlocked_WithUserName_ReturnsErrorWithUserNameInDescription", e.MethodName);
    }

    [Fact]
    public void UserBlocked_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.UserBlocked("alice", "MyMethod");
        Assert.Contains("alice", e.Description);
        Assert.Equal("MyMethod", e.MethodName);
    }

    [Fact]
    public void InvalidCredentials_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.InvalidCredentials();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("InvalidCredentials_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void InvalidCredentials_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.InvalidCredentials("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void RequiredField_ReturnsErrorWithGivenMessage()
    {
        Error e = AuthErrors.RequiredField("Email", "El campo Email es requerido");
        Assert.Equal("El campo Email es requerido", e.Description);
        Assert.Equal("RequiredField", e.MethodName);
    }

    [Fact]
    public void RequiredField_MethodNameIsAlwaysRequiredField()
    {
        Error e = AuthErrors.RequiredField("Password", "Password es obligatorio");
        Assert.Equal("RequiredField", e.MethodName);
        Assert.Equal("Password es obligatorio", e.Description);
    }

    [Fact]
    public void SamlSignatureInvalid_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlSignatureInvalid();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlSignatureInvalid_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlSignatureInvalid_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlSignatureInvalid("MyCallerMethod");
        Assert.Equal("MyCallerMethod", e.MethodName);
    }

    [Fact]
    public void SamlAssertionNotSigned_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlAssertionNotSigned();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlAssertionNotSigned_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlAssertionNotSigned_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlAssertionNotSigned("AnotherMethod");
        Assert.Equal("AnotherMethod", e.MethodName);
    }

    [Fact]
    public void SamlSignatureInvalid_And_SamlAssertionNotSigned_ReturnSameDescription()
    {
        Error sig = AuthErrors.SamlSignatureInvalid("m");
        Error ass = AuthErrors.SamlAssertionNotSigned("m");
        Assert.Equal(sig.Description, ass.Description);
    }

    [Fact]
    public void SamlAudienceMismatch_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlAudienceMismatch();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlAudienceMismatch_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlAudienceMismatch_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlAudienceMismatch("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void SamlIssuerMismatch_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlIssuerMismatch();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlIssuerMismatch_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlIssuerMismatch_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlIssuerMismatch("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void SamlAssertionExpired_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlAssertionExpired();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlAssertionExpired_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlAssertionExpired_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlAssertionExpired("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void SamlReplayDetected_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlReplayDetected();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlReplayDetected_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlReplayDetected_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlReplayDetected("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void SamlConfigurationUnavailable_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.SamlConfigurationUnavailable();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlConfigurationUnavailable_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void SamlConfigurationUnavailable_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlConfigurationUnavailable("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void SamlAudienceMismatch_And_SamlIssuerMismatch_ReturnSameDescription()
    {
        Error a = AuthErrors.SamlAudienceMismatch("m");
        Error b = AuthErrors.SamlIssuerMismatch("m");
        Assert.Equal(a.Description, b.Description);
    }

    [Fact]
    public void SamlConfigurationUnavailable_HasDifferentDescriptionThanSamlGenericError()
    {
        Error generic = AuthErrors.SamlAudienceMismatch("m");
        Error config = AuthErrors.SamlConfigurationUnavailable("m");
        Assert.NotEqual(generic.Description, config.Description);
    }

    [Fact]
    public void InsufficientPermissions_ReturnsErrorWithDescription()
    {
        Error e = AuthErrors.InsufficientPermissions();
        Assert.NotNull(e.Description);
        Assert.NotEmpty(e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("InsufficientPermissions_ReturnsErrorWithDescription", e.MethodName);
    }

    [Fact]
    public void InsufficientPermissions_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.InsufficientPermissions("ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
    }

    [Fact]
    public void SamlConfigNotFound_ReturnsErrorWithCompanyIdInDescription()
    {
        Error e = AuthErrors.SamlConfigNotFound(42);
        Assert.NotNull(e.Description);
        Assert.Contains("42", e.Description);
        Assert.Contains("AuthErrorsTest", e.ClassName);
        Assert.Contains("SamlConfigNotFound_ReturnsErrorWithCompanyIdInDescription", e.MethodName);
    }

    [Fact]
    public void SamlConfigNotFound_WithExplicitMethod_UsesProvidedMethod()
    {
        Error e = AuthErrors.SamlConfigNotFound(99, "ExplicitMethod");
        Assert.Equal("ExplicitMethod", e.MethodName);
        Assert.Contains("99", e.Description);
    }
}
