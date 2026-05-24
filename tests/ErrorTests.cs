namespace Gasolutions.Core.Patterns.Result.Tests;

public class ErrorTests
{
    [Fact]
    public void Error_None_HasEmptyProperties()
    {
        Error none = Error.None;
        Assert.Equal(string.Empty, none.Code);
        Assert.Equal(string.Empty, none.Description);
    }

    [Fact]
    public void Error_Record_StoresValues()
    {
        Error e = new("X", "desc", "className", "methodName");
        Assert.Equal("X", e.Code);
        Assert.Equal("desc", e.Description);
        Assert.Equal("className", e.ClassName);
        Assert.Equal("methodName", e.MethodName);
    }
}
