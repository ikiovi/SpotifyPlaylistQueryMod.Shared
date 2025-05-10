namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class TracksChangeSnapshotDTO : ITracksChangeSnapshot<TrackInfoDTO>
{
    public DateTimeOffset CreatedAt { get; init; }
    public required IReadOnlyList<TrackInfoDTO> Added { get; init; }
    public required IReadOnlyList<TrackInfoDTO> Removed { get; init; }
}