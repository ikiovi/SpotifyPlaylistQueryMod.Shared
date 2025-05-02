namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface ITracksChangeSnapshot<out T> where T : IBasicTrackInfo
{
    public IReadOnlyList<T> Added { get; }
    public IReadOnlyList<T> Removed { get; }
    public DateTimeOffset CreatedAt { get; init; }
}