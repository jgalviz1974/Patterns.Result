# Gasolutions.Core.Patterns.Result

> **[Español](#español) · [English](#english)**

---

<a name="español"></a>
# 🇪🇸 Español

Implementación del patrón **Result** para .NET 9. Permite manejar resultados y errores de forma explícita, evitando el uso de excepciones para flujos de control y proporcionando información contextual precisa sobre el origen del error.

## Instalación

```shell
dotnet add package Gasolutions.Core.Patterns.Result
```

## Clases principales

| Clase | Descripción |
|---|---|
| `Result` | Resultado sin valor de retorno |
| `Result<T>` | Resultado con valor de retorno tipado |
| `ResultResponse<T>` | DTO serializable para respuestas HTTP/API |
| `Error` | Registro inmutable que describe un error |
| `ErrorLanguage` | Configura el idioma de los mensajes (por defecto: español) |

## Inicio rápido

### Retornar un éxito

```csharp
public Result CrearUsuario(string nombre)
{
    // ... lógica de negocio
    return Result.Success();
}

public Result<Usuario> ObtenerUsuario(int id)
{
    var usuario = _repo.FindById(id);
    if (usuario is null)
        return Result<Usuario>.Failure(DatabaseErrors.NotFound("Usuario", id));

    return Result<Usuario>.Success(usuario);
}
```

### Retornar un error

```csharp
public Result<Producto> ObtenerProducto(int id)
{
    var producto = _db.Productos.Find(id);
    if (producto is null)
        return Result<Producto>.Failure(DatabaseErrors.NotFound("Producto", id));

    return Result<Producto>.Success(producto);
}
```

### Consumir el resultado

```csharp
var resultado = ObtenerProducto(42);

if (resultado.IsFailure)
{
    Console.WriteLine($"Error [{resultado.Error.Code}]: {resultado.Error.Description}");
    Console.WriteLine($"Origen: {resultado.Error.ClassName}.{resultado.Error.MethodName}");
    return;
}

Console.WriteLine($"Producto: {resultado.Value.Nombre}");
```

### Usar `ResultResponse<T>` en una API

```csharp
[HttpGet("{id}")]
public IActionResult GetProducto(int id)
{
    var resultado = _service.ObtenerProducto(id);

    if (resultado.IsFailure)
        return NotFound(new ResultResponse<Producto>
        {
            IsFailure = true,
            Error = resultado.Error
        });

    return Ok(new ResultResponse<Producto>
    {
        IsSuccess = true,
        Value = resultado.Value
    });
}
```

---

## Fábricas de errores disponibles

| Fábrica | Cuándo usarla |
|---|---|
| `ArgumentErrors` | Argumentos inválidos en métodos |
| `AuthErrors` | Autenticación y autorización |
| `AzureStorageErrors` | Azure Blob Storage |
| `CommunicationErrors` | Conexión a servicios externos |
| `ContainerErrors` | Validación de contenedores y archivos |
| `DatabaseErrors` | Acceso a datos y consultas |
| `EmailErrors` | Proveedor de correo electrónico |
| `EnviromentVariableErrors` | Variables de entorno |
| `ExceptionErrors` | Excepciones no controladas |
| `HttpErrors` | Comunicación HTTP |
| `KeyValueErrors` | Claves inválidas |
| `OtherErrors` | Errores misceláneos |
| `TokenErrors` | Obtención de tokens |
| `TwoFactorErrors` | Autenticación de dos factores |

### Ejemplos por fábrica

```csharp
// ArgumentErrors
ArgumentErrors.NoValid("string", "correo", "no tiene formato válido");

// AuthErrors
AuthErrors.InvalidCredentials();
AuthErrors.UserBlocked("jgalviz");
AuthErrors.InsufficientPermissions();
AuthErrors.SamlConfigNotFound(companyId: 5);

// AzureStorageErrors
AzureStorageErrors.BlobNotFound("mi-contenedor", "archivo.pdf");

// CommunicationErrors
CommunicationErrors.CommunicationError("PaymentService", "timeout después de 30s");

// ContainerErrors
ContainerErrors.InvalidContainerName();
ContainerErrors.LocalFileNotFound("/tmp/reporte.pdf");

// DatabaseErrors
DatabaseErrors.NotFound("Factura", 1001);                            // por ID
DatabaseErrors.NotFound("Factura", "NumeroFactura", "F-2024-001");   // por campo y valor
DatabaseErrors.NotFound("Caja", "CodigoCaja", isMale: false);        // género femenino
DatabaseErrors.TableWithoutRegisters("Producto");
DatabaseErrors.NotUpdated("Pedido", 55, "registro bloqueado");
DatabaseErrors.AssociatedRegisters("CajaVenta", stationId: 3);
DatabaseErrors.ForeingRelationViolated("el mensaje de error del motor de BD");

// EmailErrors
EmailErrors.InvalidResponse();
EmailErrors.InvalidResponse("SMTP 550: buzón lleno");
EmailErrors.Others("El proveedor rechazó el adjunto");   // mensaje libre

// EnviromentVariableErrors
EnviromentVariableErrors.NoFound("CONNECTION_STRING");

// ExceptionErrors
ExceptionErrors.ExceptionNotControlled(ex);
ExceptionErrors.ExceptionNotControlledInvokingServiceMethod("UserService", ex);

// HttpErrors
HttpErrors.UnAuthorized("https://api.pagos.com/cobros");
HttpErrors.BadResponse("FacturaDto", responseBody);
HttpErrors.InternalServerError(responseBody);            // mensaje del servidor, no localizado

// KeyValueErrors
KeyValueErrors.NoValid("clave-inv@lida");

// OtherErrors
OtherErrors.NotDefined("Ocurrió algo inesperado");       // mensaje libre
OtherErrors.CommunicationError(["ServicioA", "ServicioB"]);
OtherErrors.MessageMismatch(["ok", "procesado"], ["error", "timeout"]);

// TokenErrors
TokenErrors.GettingProblem("IdentityServer");

// TwoFactorErrors
TwoFactorErrors.EmailNotConfirmed();
TwoFactorErrors.UserNotFound("jgalviz");
TwoFactorErrors.OtpInvalid();
TwoFactorErrors.OtpExpired();
TwoFactorErrors.InvalidCredentials();
```

---

## Soporte de idiomas (Español / Inglés)

Por defecto la librería devuelve todos los mensajes en **español**. Para cambiar el idioma usa `ErrorLanguage.Current`:

```csharp
using System.Globalization;
using Gasolutions.Core.Patterns.Result.Localization;

// Cambiar a inglés
ErrorLanguage.Current = new CultureInfo("en");

// Volver a español
ErrorLanguage.Current = new CultureInfo("es");
```

### Ejemplo de salida por idioma

```csharp
// --- Español (por defecto) ---
var err = DatabaseErrors.NotFound("Producto", 42);
// Description → "Producto 42 no fue encontrado."

// --- Inglés ---
ErrorLanguage.Current = new CultureInfo("en");
var err = DatabaseErrors.NotFound("Product", 42);
// Description → "Product 42 was not found."
```

### Configuración global en ASP.NET Core

Configura el idioma una sola vez en el arranque de la aplicación:

```csharp
// Program.cs
ErrorLanguage.Current = new CultureInfo(
    builder.Configuration["AppLanguage"] ?? "es"
);
```

> **Nota:** Los mensajes que son **texto libre del llamador** (p. ej., `OtherErrors.NotDefined`, `AuthErrors.RequiredField`, `HttpErrors.InternalServerError`) no se localizan; la librería los pasa tal cual.

---

## La estructura del `Error`

```csharp
public sealed record Error(
    string Code,         // Código auto-generado: "NombreClase.NombreMetodo"
    string Description,  // Mensaje localizado o texto del llamador
    string ClassName,    // Clase que invocó la fábrica
    string MethodName    // Método que invocó la fábrica
);
```

### Ejemplo de inspección

```csharp
var error = DatabaseErrors.NotFound("Orden", 99);

Console.WriteLine(error.Code);        // "DatabaseErrors.NotFound"
Console.WriteLine(error.Description); // "Orden 99 no fue encontrada."
Console.WriteLine(error.ClassName);   // Clase del llamador
Console.WriteLine(error.MethodName);  // Método del llamador
```

---

## Patrón recomendado en capas

```csharp
// Capa de dominio / servicio
public Result<Pedido> ProcesarPedido(int pedidoId)
{
    var pedido = _repo.Find(pedidoId);
    if (pedido is null)
        return Result<Pedido>.Failure(DatabaseErrors.NotFound("Pedido", pedidoId));

    if (!pedido.PuedesProcesarse())
        return Result<Pedido>.Failure(OtherErrors.NotDefined("El pedido no está en estado válido para procesarse."));

    pedido.Procesar();
    _repo.Save(pedido);
    return Result<Pedido>.Success(pedido);
}

// Capa de API
[HttpPost("{id}/procesar")]
public IActionResult Procesar(int id)
{
    var resultado = _service.ProcesarPedido(id);

    return resultado.IsSuccess
        ? Ok(resultado.Value)
        : BadRequest(resultado.Error);
}
```

---

<a name="english"></a>
# 🇺🇸 English

**Result pattern** implementation for .NET 9. Provides explicit handling of operation results and errors — avoiding exceptions for flow control — with precise contextual information about where each error originated.

## Installation

```shell
dotnet add package Gasolutions.Core.Patterns.Result
```

## Core classes

| Class | Description |
|---|---|
| `Result` | Result without a return value |
| `Result<T>` | Result with a typed return value |
| `ResultResponse<T>` | Serializable DTO for HTTP/API responses |
| `Error` | Immutable record describing an error |
| `ErrorLanguage` | Configures the message language (default: Spanish) |

## Quick start

### Returning success

```csharp
public Result CreateUser(string name)
{
    // ... business logic
    return Result.Success();
}

public Result<User> GetUser(int id)
{
    var user = _repo.FindById(id);
    if (user is null)
        return Result<User>.Failure(DatabaseErrors.NotFound("User", id));

    return Result<User>.Success(user);
}
```

### Returning an error

```csharp
public Result<Product> GetProduct(int id)
{
    var product = _db.Products.Find(id);
    if (product is null)
        return Result<Product>.Failure(DatabaseErrors.NotFound("Product", id));

    return Result<Product>.Success(product);
}
```

### Consuming the result

```csharp
var result = GetProduct(42);

if (result.IsFailure)
{
    Console.WriteLine($"Error [{result.Error.Code}]: {result.Error.Description}");
    Console.WriteLine($"Origin: {result.Error.ClassName}.{result.Error.MethodName}");
    return;
}

Console.WriteLine($"Product: {result.Value.Name}");
```

### Using `ResultResponse<T>` in an API

```csharp
[HttpGet("{id}")]
public IActionResult GetProduct(int id)
{
    var result = _service.GetProduct(id);

    if (result.IsFailure)
        return NotFound(new ResultResponse<Product>
        {
            IsFailure = true,
            Error = result.Error
        });

    return Ok(new ResultResponse<Product>
    {
        IsSuccess = true,
        Value = result.Value
    });
}
```

---

## Available error factories

| Factory | When to use |
|---|---|
| `ArgumentErrors` | Invalid method arguments |
| `AuthErrors` | Authentication and authorization |
| `AzureStorageErrors` | Azure Blob Storage |
| `CommunicationErrors` | External service connectivity |
| `ContainerErrors` | Container and file validation |
| `DatabaseErrors` | Data access and queries |
| `EmailErrors` | Email provider |
| `EnviromentVariableErrors` | Environment variables |
| `ExceptionErrors` | Unhandled exceptions |
| `HttpErrors` | HTTP communication |
| `KeyValueErrors` | Invalid keys |
| `OtherErrors` | Miscellaneous errors |
| `TokenErrors` | Token acquisition |
| `TwoFactorErrors` | Two-factor authentication |

---

## Language support (Spanish / English)

By default all messages are in **Spanish**. Switch languages with `ErrorLanguage.Current`:

```csharp
using System.Globalization;
using Gasolutions.Core.Patterns.Result.Localization;

// Switch to English
ErrorLanguage.Current = new CultureInfo("en");

// Back to Spanish
ErrorLanguage.Current = new CultureInfo("es");
```

### Sample output per language

```csharp
// --- Spanish (default) ---
var err = DatabaseErrors.NotFound("Producto", 42);
// Description → "Producto 42 no fue encontrado."

// --- English ---
ErrorLanguage.Current = new CultureInfo("en");
var err = DatabaseErrors.NotFound("Product", 42);
// Description → "Product 42 was not found."
```

### Global setup in ASP.NET Core

```csharp
// Program.cs
ErrorLanguage.Current = new CultureInfo(
    builder.Configuration["AppLanguage"] ?? "es"
);
```

> **Note:** Caller-supplied free-text messages (e.g., `OtherErrors.NotDefined`, `AuthErrors.RequiredField`, `HttpErrors.InternalServerError`) are **not** localized by the library — they are passed through as-is.

---

## The `Error` record structure

```csharp
public sealed record Error(
    string Code,         // Auto-generated: "ClassName.MethodName"
    string Description,  // Localized message or caller-supplied text
    string ClassName,    // Class that called the factory
    string MethodName    // Method that called the factory
);
```

---

## Recommended layered pattern

```csharp
// Domain / service layer
public Result<Order> ProcessOrder(int orderId)
{
    var order = _repo.Find(orderId);
    if (order is null)
        return Result<Order>.Failure(DatabaseErrors.NotFound("Order", orderId));

    if (!order.CanBeProcessed())
        return Result<Order>.Failure(OtherErrors.NotDefined("Order is not in a valid state for processing."));

    order.Process();
    _repo.Save(order);
    return Result<Order>.Success(order);
}

// API layer
[HttpPost("{id}/process")]
public IActionResult Process(int id)
{
    var result = _service.ProcessOrder(id);

    return result.IsSuccess
        ? Ok(result.Value)
        : BadRequest(result.Error);
}
```

---

## License

MIT © Gasolutions SAS
