using System.Text.Json.Serialization;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class TrackInfoDTO : IBasicTrackInfo, IFullTrackInfo
{
    [JsonRequired]
    public required string TrackId { get; init; }
    [JsonRequired]
    public required string ArtistId { get; init; }
    [JsonRequired]
    public required string AlbumId { get; init; }
    public DateTime AddedAt { get; init; }
}