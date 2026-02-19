namespace Gasolutions.Core.ResultPattern.Tests;

public class DatabaseErrorsTests
{
    [Fact]
    public void TableWithoutRegisters_ReturnsExpectedCodeAndMessage()
    {
        Error e = DatabaseErrors.TableWithoutRegisters("MyTable");
        Assert.Equal("DatabaseErrors.TableWithoutRegisters", e.Code);
        Assert.Contains("DatabaseErrorsTest", e.ClassName);
        Assert.Contains("TableWithoutRegisters_ReturnsExpectedCodeAndMessage", e.MethodName);
        Assert.Contains("MyTable", e.Description);
    }

    [Fact]
    public void NotFound_ById_MaleAndFemale()
    {
        Error male = DatabaseErrors.NotFound("Entity", 5, true);
        Assert.Contains("Entity 5 no fue encontrado", male.Description);

        Error female = DatabaseErrors.NotFound("Entity", 5, false);
        Assert.Contains("Entity 5 no fue encontrada", female.Description);
        Assert.Contains("DatabaseErrorsTest", male.ClassName);
        Assert.Contains("NotFound_ById_MaleAndFemale", male.MethodName);
    }

    [Fact]
    public void NotFound_ByField_ReturnsMessage()
    {
        Error e = DatabaseErrors.NotFound("Entity", "DNI", "X123");
        Assert.Contains("DNI", e.Description);
        Assert.Contains("X123", e.Description);
        Assert.Contains("DatabaseErrorsTest", e.ClassName);
        Assert.Contains("NotFound_ByField_ReturnsMessage", e.MethodName);
    }

    [Fact]
    public void NotFound_ByField_MaleAndFemale()
    {
        Error male = DatabaseErrors.NotFound("Usuario", "Email", "user@example.com", true);
        Assert.Equal("DatabaseErrors.NotFound", male.Code);
        Assert.Contains("DatabaseErrorsTest", male.ClassName);
        Assert.Contains("NotFound_ByField_MaleAndFemale", male.MethodName);
        Assert.Contains("Usuario con [Email]: user@example.com", male.Description);
        Assert.Contains("no fue encontrado", male.Description);

        Error female = DatabaseErrors.NotFound("Usuario", "Email", "user@example.com", false);
        Assert.Contains("Usuario con [Email]: user@example.com", female.Description);
        Assert.Contains("no fue encontrada", female.Description);
    }

    [Fact]
    public void TableWithoutRegisters_WithMessage_ReturnsExpectedCodeAndMessage()
    {
        Error e = DatabaseErrors.TableWithoutRegisters("Usuarios");
        Assert.Equal("DatabaseErrors.TableWithoutRegisters", e.Code);
        Assert.Contains("DatabaseErrorsTest", e.ClassName);
        Assert.Contains("TableWithoutRegisters_WithMessage_ReturnsExpectedCodeAndMessage", e.MethodName);
        Assert.Contains("Usuarios", e.Description);
    }

    [Fact]
    public void NotUpdated_MaleAndFemale()
    {
        Error male = DatabaseErrors.NotUpdated("Usuario", 1, "Registro no existe", true);
        Assert.Equal("DatabaseErrors.NotUpdated", male.Code);
        Assert.Contains("DatabaseErrorsTest", male.ClassName);
        Assert.Contains("NotUpdated_MaleAndFemale", male.MethodName);
        Assert.Contains("Usuario 1 no fue actualizado", male.Description);
        Assert.Contains("Registro no existe", male.Description);

        Error female = DatabaseErrors.NotUpdated("Usuario", 1, "Registro no existe", false);
        Assert.Contains("Usuario 1 no fue actualizadada", female.Description);
        Assert.Contains("Registro no existe", female.Description);
    }

    [Fact]
    public void AssociatedRegisters_ReturnsExpectedCodeAndMessage()
    {
        Error e = DatabaseErrors.AssociatedRegisters("Vehículo", 5);
        Assert.Equal("DatabaseErrors.AssociatedRegisters", e.Code);
        Assert.Contains("DatabaseErrorsTest", e.ClassName);
        Assert.Contains("AssociatedRegisters_ReturnsExpectedCodeAndMessage", e.MethodName);
        Assert.Contains("Vehículo", e.Description);
        Assert.Contains("5", e.Description);
        Assert.Contains("ventas asociadas", e.Description);
    }

    [Fact]
    public void ForeingRelationViolated_WithValidMatch_ReturnsExtractedValues()
    {
        string errorMessage = "FOREIGN KEY (`VehicleId`) REFERENCES `vehicles` (`Id`)";
        Error e = DatabaseErrors.ForeingRelationViolated("Orders", errorMessage);

        Assert.Equal("DatabaseErrors.ForeingRelationViolated", e.Code);
        Assert.Contains("DatabaseErrorsTest", e.ClassName);
        Assert.Contains("ForeingRelationViolated_WithValidMatch_ReturnsExtractedValues", e.MethodName);
        Assert.Contains("Orders", e.Description);
        Assert.Contains("vehicles", e.Description);
        Assert.Contains("Id", e.Description);
    }

    [Fact]
    public void ForeingRelationViolated_WithoutMatch_ReturnsMessageWithEmptyValues()
    {
        string errorMessage = "Invalid error message format";
        Error e = DatabaseErrors.ForeingRelationViolated("Orders", errorMessage);

        Assert.Equal("DatabaseErrors.ForeingRelationViolated", e.Code);
        Assert.Contains("DatabaseErrorsTest", e.ClassName);
        Assert.Contains("ForeingRelationViolated_WithoutMatch_ReturnsMessageWithEmptyValues", e.MethodName);
        Assert.Contains("Orders", e.Description);
    }
}
