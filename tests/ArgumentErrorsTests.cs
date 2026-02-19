namespace Gasolutions.Core.ResultPattern.Tests;

public class ArgumentErrorsTests
{
    [Fact]
    public void NoValid_ReturnsExpectedCode()
    {
        Error e = ArgumentErrors.NoValid("string", "userName", "no puede ser vacío");
        Assert.Equal("ArgumentErrors.NoValid", e.Code);
    }

    [Fact]
    public void NoValid_IncludesAllParameters()
    {
        Error e = ArgumentErrors.NoValid("int", "age", "debe ser mayor a 18");
        Assert.Contains("age", e.Description);
        Assert.Contains("int", e.Description);
        Assert.Contains("debe ser mayor a 18", e.Description);
    }

    [Fact]
    public void NoValid_IncludesCallerClassName()
    {
        Error e = ArgumentErrors.NoValid("string", "email", "formato inválido");
        Assert.Contains("ArgumentErrorsTests", e.Description);
        Assert.Contains("NoValid_IncludesCallerClassName", e.Description);
    }
}