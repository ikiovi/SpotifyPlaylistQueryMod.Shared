namespace SpotifyPlaylistQueryMod.Shared.API;

public interface IChangedTracks<out T> where T : IBasicTrackInfo
{
    public IReadOnlyList<T> Added { get; }
    public IReadOnlyList<T> Removed { get; }
    public bool HasChanges => Added.Count + Removed.Count > 0;
}