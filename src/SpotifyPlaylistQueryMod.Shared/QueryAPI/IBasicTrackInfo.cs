namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface IBasicTrackInfo
{
    public string TrackId { get; }
    public DateTime AddedAt { get; }
}
