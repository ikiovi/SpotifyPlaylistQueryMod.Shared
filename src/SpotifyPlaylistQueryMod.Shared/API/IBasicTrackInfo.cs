namespace SpotifyPlaylistQueryMod.Shared.API;

public interface IBasicTrackInfo
{
    public string TrackId { get; }
    public DateTime AddedAt { get; }
}
