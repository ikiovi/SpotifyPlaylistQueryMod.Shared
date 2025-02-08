using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface IPlaylistChangeRequest<out T> where T : IBasicTrackInfo
{
    public int QueryId { get; }
    public PlaylistQueryInputType InputType { get; }
    public IReadOnlyList<T>? ModifiedSourcePlaylist { get; }
    public IReadOnlyList<T>? OriginalSourcePlaylist { get; }
    public IReadOnlyList<T>? CurrentTargetPlaylist { get; }
    public IChangedTracks<T>? ChangedTracks { get; }
}
