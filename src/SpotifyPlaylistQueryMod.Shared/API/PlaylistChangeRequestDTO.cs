using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.API;

public class PlaylistChangeRequestDTO
{
    public required int QueryId { get; init; }
    public PlaylistQueryInputType InputType { get; init; }
    public IReadOnlyList<IBasicTrackInfo>? ModifiedSourcePlaylist { get; set; }
    public IReadOnlyList<IBasicTrackInfo>? OriginalSourcePlaylist { get; set; }
    public IReadOnlyList<IBasicTrackInfo>? CurrentTargetPlaylist { get; set; }
    public IChangedTracks<IBasicTrackInfo>? ChangedTracks { get; set; }
}

public class PlaylistChangeResponseDTO
{
    public int Position { get; init; }
    public required List<string> Add { get; set; }
    public required List<string> Remove { get; set; }
    public PlaylistQueryInputType NewInputType { get; init; }
}

public interface IChangedTracks<out T> where T : IBasicTrackInfo
{
    public IReadOnlyList<T> Added { get; }
    public IReadOnlyList<T> Removed { get; }
    public bool HasChanges => Added.Count + Removed.Count > 0;
}

public interface IBasicTrackInfo
{
    public string TrackId { get; }
    public DateTime AddedAt { get; }
}

