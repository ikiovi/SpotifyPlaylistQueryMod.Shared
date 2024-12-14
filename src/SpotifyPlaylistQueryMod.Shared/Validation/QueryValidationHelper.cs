using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SpotifyPlaylistQueryMod.Shared.Validation;
internal static partial class QueryValidationHelper
{
    public static readonly Regex Base64Expression = Base64Regex();

    public static ValidationResult? ValidateSpotifyId(string? playlistId, string propertyName, bool nullable = false)
    {
        if (nullable && playlistId is null) return null;
        if (string.IsNullOrWhiteSpace(playlistId))
        {
            return new ValidationResult($"{propertyName} is required.", [propertyName]);
        }
        if (Base64Expression.IsMatch(playlistId)) return null;
        return new ValidationResult($"{propertyName} should be valid base-62 string.", [propertyName]);
    }

    public static bool IsValidQueryString(this ValidationContext context, string query)
    {
        return Uri.TryCreate(query, UriKind.Absolute, out Uri? uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    [GeneratedRegex(@"^[a-zA-Z0-9]+$")]
    public static partial Regex Base64Regex();
}
