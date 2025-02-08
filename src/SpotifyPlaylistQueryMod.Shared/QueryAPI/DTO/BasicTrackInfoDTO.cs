using System.Text.Json.Serialization;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class BasicTrackInfoDTO : IBasicTrackInfo
{
    [JsonRequired]
    public required string TrackId { get; init; }
    public DateTime AddedAt { get; init; }
}