namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class TrackInfoDTO : ITrackInfo
{
    public required string TrackId { get; init; }
    public required string ArtistId { get; init; }
    public required string AlbumId { get; init; }
    public DateTime AddedAt { get; init; }
}