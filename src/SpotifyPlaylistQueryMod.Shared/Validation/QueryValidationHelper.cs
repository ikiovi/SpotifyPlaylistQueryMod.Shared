using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;
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
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps) &&
            !uri.IsLoopback &&
            IsNonLocalIpAddress(uri.Host);
    }

    public static bool IsNonLocalIpAddress(string hostname)
    {
        if (!IPAddress.TryParse(hostname, out IPAddress? ipAddress)) return true;
        if (ipAddress.AddressFamily != AddressFamily.InterNetwork || IPAddress.IsLoopback(ipAddress)) return false;

        return ipAddress.GetAddressBytes() switch
        {
            [0, 0, 0, 0] => false,
            [10, ..] or [172, >= 16 and <= 31, ..] or [192, 168, ..] => false,
            _ => true
        };
    }

    [GeneratedRegex(@"^[a-zA-Z0-9]+$")]
    public static partial Regex Base64Regex();
}
