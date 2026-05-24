namespace Gasolutions.Core.Patterns.Result.Tests;

public class OtherErrorsTests
{
    [Fact]
    public void NotDefined_ReturnsExpectedCode()
    {
        Error e = OtherErrors.NotDefined("Feature not implemented yet");
        Assert.Equal("OtherErrors.NotDefined", e.Code);
    }

    [Fact]
    public void NotDefined_IncludesMessage()
    {
        Error e = OtherErrors.NotDefined("Scenario XYZ not handled");
        Assert.Contains("Scenario XYZ not handled", e.Description);
    }

    [Fact]
    public void NotDefined_IncludesCallerContext()
    {
        Error e = OtherErrors.NotDefined("Test message");
        Assert.Contains("OtherErrorsTests", e.ClassName);
        Assert.Contains("NotDefined_IncludesCallerContext", e.MethodName);
    }
}