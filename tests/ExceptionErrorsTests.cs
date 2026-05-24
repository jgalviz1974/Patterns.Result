using System;

namespace Gasolutions.Core.Patterns.Result.Tests;

public class ExceptionErrorsTests
{
    [Fact]
    public void ExceptionNotControlled_GeneratesDetailedMessage()
    {
        InvalidOperationException ex = new("boom")
        {
            Source = "UnitTest",
        };
        Error err = ExceptionErrors.ExceptionNotControlled(ex);
        Assert.Equal("ExceptionErrors.ExceptionNotControlled", err.Code);
        Assert.Contains("no controlada", err.Description);
        Assert.Contains("InvalidOperationException", err.Description);
        Assert.Contains("boom", err.Description);
    }

    [Fact]
    public void AppendException_IncludesInnerExceptionsAndData()
    {
        Exception inner = new("inner msg.");
        Exception outer = new("outer msg", inner);
        outer.Data["token"] = "secret-value"; // should be hidden
        Error err = ExceptionErrors.ExceptionNotControlled(outer);
        Assert.Contains("outer msg", err.Description);
        Assert.Contains("inner msg", err.Description);
        Assert.Contains("(oculto)", err.Description);
    }
}