using System.Text.Json.Serialization;
using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class PlaylistChangeRequestDTO : IPlaylistChangeRequest<BasicTrackInfoDTO>
{
    [JsonRequired]
    public required int QueryId { get; init; }
    [JsonRequired]
    public required PlaylistQueryInputType InputType { get; init; }
    public IReadOnlyList<BasicTrackInfoDTO>? ModifiedSourcePlaylist { get; init; }
    public IReadOnlyList<BasicTrackInfoDTO>? OriginalSourcePlaylist { get; init; }
    public IReadOnlyList<BasicTrackInfoDTO>? CurrentTargetPlaylist { get; init; }
    public ChangedTracksDTO? ChangedTracks { get; init; }

    IChangedTracks<BasicTrackInfoDTO>? IPlaylistChangeRequest<BasicTrackInfoDTO>.ChangedTracks => ChangedTracks;
}