namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface ITrackInfo : ITrackCore
{
    public string ArtistId { get; }
    public string AlbumId { get; }
}

public interface ITrackCore
{
    public string TrackId { get; }
    public DateTime AddedAt { get; }
}