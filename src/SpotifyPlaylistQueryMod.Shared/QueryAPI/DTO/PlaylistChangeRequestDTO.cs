using System.Text.Json.Serialization;
using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class PlaylistChangeRequestDTO : IPlaylistChangeRequest<TrackInfoDTO>
{
    [JsonRequired]
    public required int QueryId { get; init; }
    [JsonRequired]
    public required PlaylistQueryInputType InputType { get; init; }
    public IReadOnlyList<TrackInfoDTO>? ModifiedSourcePlaylist { get; init; }
    public IReadOnlyList<TrackInfoDTO>? CurrentTargetPlaylist { get; init; }
    public IReadOnlyList<TracksChangeSnapshotDTO>? ChangeHistory { get; init; }

    IReadOnlyList<ITracksChangeSnapshot<TrackInfoDTO>>? IPlaylistChangeRequest<TrackInfoDTO>.ChangeHistory => ChangeHistory;
}