using System.Globalization;

namespace Gasolutions.Core.Patterns.Result.Localization
{
    /// <summary>
    /// Configures the language used for error messages in the library.
    /// The default language is Spanish.
    /// </summary>
    /// <example>
    /// // Switch to English
    /// ErrorLanguage.Current = new CultureInfo("en");
    /// </example>
    public static class ErrorLanguage
    {
        private static CultureInfo current = new("es");

        /// <summary>
        /// Gets or sets the culture used to resolve error messages.
        /// Defaults to Spanish (<c>es</c>). Assigning <c>null</c> resets to Spanish.
        /// </summary>
        public static CultureInfo Current
        {
            get => current;
            set => current = value ?? new CultureInfo("es");
        }
    }
}
