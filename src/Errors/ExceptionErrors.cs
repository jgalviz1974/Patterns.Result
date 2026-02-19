using System.Collections;
using System.Text;

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Factory class for creating exception-related errors.
    /// </summary>
    public static class ExceptionErrors
    {
        /// <summary>
        /// Error when an uncontrolled exception occurs while invoking a service method.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <param name="wcfMethod">The WCF method that was being invoked.</param>
        /// <param name="value">The exception that occurred.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object representing the exception.</returns>
        public static Error ExceptionNotControlledInvokingServiceMethod(string serviceName, string wcfMethod, Exception value, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            string key = $"{stack.ErrorCode}.{serviceName}.{wcfMethod}.ExceptionNotControlledInvokingServiceMethod";
            string message = BuildDetailedExceptionMessage(stack.ErrorCode, value);
            return new Error(key, message);
        }

        /// <summary>
        /// Error when an uncontrolled exception occurs.
        /// </summary>
        /// <param name="value">The exception that occurred.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object representing the exception.</returns>
        public static Error ExceptionNotControlled(Exception value, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            string key = $"{stack.ErrorCode}";
            string message = BuildDetailedExceptionMessage(stack.ErrorCode, value);
            return new Error(key, message);
        }

        /// <summary>
        /// Builds a detailed exception message with comprehensive exception information.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="ex">The exception to format.</param>
        /// <returns>A formatted string containing detailed exception information.</returns>
        private static string BuildDetailedExceptionMessage(string errorCode, Exception ex)
        {
            StringBuilder sb = new(1024);

            _ = sb.AppendLine($"🛑 Excepción no controlada en {errorCode}.()");
            _ = sb.AppendLine();

            AppendException(sb, ex, level: 0);

            return sb.ToString();
        }

        /// <summary>
        /// Adds exception information to a <see cref="StringBuilder"/> recursively.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> to which the information will be added.</param>
        /// <param name="ex">The exception from which information will be obtained.</param>
        /// <param name="level">The current depth level (for inner exceptions).</param>
        private static void AppendException(StringBuilder sb, Exception ex, int level)
        {
            // Prefijo para niveles de inner exception
            string indent = new(' ', level * 2);
            string header = level == 0 ? "Exception" : $"InnerException (nivel {level})";

            _ = sb.AppendLine($"{indent}=== {header} ===");
            _ = sb.AppendLine($"{indent}Tipo      : {ex.GetType().FullName}");
            _ = sb.AppendLine($"{indent}Mensaje   : {ex.Message}");

            // Propiedades útiles del contexto
            if (ex.HResult != 0)
            {
                _ = sb.AppendLine($"{indent}HResult   : 0x{ex.HResult:X8} ({ex.HResult})");
            }

            if (!string.IsNullOrWhiteSpace(ex.Source))
            {
                _ = sb.AppendLine($"{indent}Source    : {ex.Source}");
            }

            if (ex.TargetSite is not null)
            {
                _ = sb.AppendLine($"{indent}TargetSite: {ex.TargetSite.DeclaringType?.FullName}.{ex.TargetSite.Name}()");
            }

            if (!string.IsNullOrWhiteSpace(ex.HelpLink))
            {
                _ = sb.AppendLine($"{indent}HelpLink  : {ex.HelpLink}");
            }

            // Data (clave-valor)
            AppendExceptionData(sb, ex.Data, indent);

            // StackTrace
            _ = sb.AppendLine($"{indent}StackTrace:");
            if (!string.IsNullOrWhiteSpace(ex.StackTrace))
            {
                // Normaliza saltos de línea y agrega indentación
                string[] lines = ex.StackTrace.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    _ = sb.AppendLine($"{indent}  {line.Trim()}");
                }
            }
            else
            {
                _ = sb.AppendLine($"{indent}  (no disponible)");
            }

            _ = sb.AppendLine(); // Separador visual

            // Manejo especial de AggregateException (para tareas/paralelismo)
            if (ex is AggregateException agg)
            {
                AggregateException flattened = agg.Flatten();
                int i = 0;
                foreach (Exception inner in flattened.InnerExceptions)
                {
                    _ = sb.AppendLine($"{indent}--- Aggregate Inner #{i} ---");
                    AppendException(sb, inner, level + 1);
                    i++;
                }

                return;
            }

            // Recursión normal de InnerException
            if (ex.InnerException is not null)
            {
                AppendException(sb, ex.InnerException, level + 1);
            }
        }

        /// <summary>
        /// Adds the exception's data dictionary information to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> to which the information will be added.</param>
        /// <param name="data">The exception's data dictionary.</param>
        /// <param name="indent">Indentation string.</param>
        private static void AppendExceptionData(StringBuilder sb, IDictionary data, string indent)
        {
            try
            {
                if (data is null || data.Count == 0)
                {
                    _ = sb.AppendLine($"{indent}Data      : (vacío)");
                    return;
                }

                _ = sb.AppendLine($"{indent}Data      :");
                foreach (DictionaryEntry entry in data)
                {
                    string key = SafeToString(entry.Key);
                    string val = SafeToString(entry.Value);

                    // Evita volcar potenciales secretos (heurística muy simple)
                    if (IsLikelySecret(key))
                    {
                        val = "*** (oculto) ***";
                    }

                    _ = sb.AppendLine($"{indent}  - {key}: {val}");
                }
            }
            catch (Exception dataEx)
            {
                _ = sb.AppendLine($"{indent}Data      : (error al leer Data: {dataEx.GetType().Name} - {dataEx.Message})");
            }
        }

        private static string SafeToString(object? obj)
        {
            if (obj is null)
            {
                return "(null)";
            }

            try
            {
                return obj.ToString() ?? "(null)";
            }
            catch
            {
                return $"({obj.GetType().FullName} .ToString() falló)";
            }
        }

        // Heurística básica para no exponer secretos/tokens contraseñas
        private static bool IsLikelySecret(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            key = key.ToLowerInvariant();
            return key.Contains("password") ||
                   key.Contains("pwd") ||
                   key.Contains("secret") ||
                   key.Contains("token") ||
                   key.Contains("apikey") ||
                   key.Contains("connectionstring");
        }
    }
}