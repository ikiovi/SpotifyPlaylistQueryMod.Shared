using System.Text.Json.Serialization;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface IChangedTracks<out T> where T : IBasicTrackInfo
{
    public IReadOnlyList<T> Added { get; }
    public IReadOnlyList<T> Removed { get; }
}