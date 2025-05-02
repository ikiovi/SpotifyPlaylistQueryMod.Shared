using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI;

public interface IPlaylistChangeRequest<out T> where T : IBasicTrackInfo, IFullTrackInfo
{
    public int QueryId { get; }
    public PlaylistQueryInputType InputType { get; }
    public IReadOnlyList<T>? ModifiedSourcePlaylist { get; }
    public IReadOnlyList<T>? CurrentTargetPlaylist { get; }
    public IReadOnlyList<ITracksChangeSnapshot<T>>? ChangeHistory { get; }
}
