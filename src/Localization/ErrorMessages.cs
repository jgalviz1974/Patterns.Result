using System.Resources;

namespace Gasolutions.Core.Patterns.Result.Localization
{
    /// <summary>
    /// Internal helper that resolves localized error message templates
    /// from the embedded resource files using the active <see cref="ErrorLanguage.Current"/> culture.
    /// </summary>
    internal static class ErrorMessages
    {
        private static readonly ResourceManager RM = new("Gasolutions.Core.Patterns.Result.Resources.Messages", typeof(ErrorMessages).Assembly);

        /// <summary>
        /// Returns the localized message for <paramref name="key"/>, optionally
        /// formatting it with <paramref name="args"/> via <see cref="string.Format"/>.
        /// Falls back to the key name itself when the resource is not found.
        /// </summary>
        internal static string Get(string key, params object[] args)
        {
            string template = RM.GetString(key, ErrorLanguage.Current) ?? key;
            return args.Length == 0 ? template : string.Format(template, args);
        }
    }
}
