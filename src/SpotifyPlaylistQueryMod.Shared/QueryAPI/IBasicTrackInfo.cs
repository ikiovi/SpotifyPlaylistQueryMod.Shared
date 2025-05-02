namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface IBasicTrackInfo
{
    public string TrackId { get; }
    public DateTime AddedAt { get; }
}

public interface IFullTrackInfo : IBasicTrackInfo
{
    public string ArtistId { get; }
    public string AlbumId { get; }
}