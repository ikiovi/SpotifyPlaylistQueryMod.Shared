using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface IPlaylistChangeRequest<out T> where T : ITrackInfo
{
    public int QueryId { get; }
    public PlaylistQueryInputType InputType { get; }
    public IReadOnlyList<T>? CurrentSourcePlaylist { get; }
    public IReadOnlyList<T>? CurrentTargetPlaylist { get; }
    public IReadOnlyList<ITracksChangeSnapshot<T>>? ChangeHistory { get; }
}
