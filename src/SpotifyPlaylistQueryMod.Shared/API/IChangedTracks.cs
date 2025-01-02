using System.Text.Json.Serialization;

namespace SpotifyPlaylistQueryMod.Shared.API;

public interface IChangedTracks<out T> where T : IBasicTrackInfo
{
    public IReadOnlyList<T> Added { get; }
    public IReadOnlyList<T> Removed { get; }
    [JsonIgnore]
    public bool HasChanges => Added.Count + Removed.Count > 0;
}