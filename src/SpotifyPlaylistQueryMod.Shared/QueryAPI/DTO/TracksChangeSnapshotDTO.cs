using System.Text.Json.Serialization;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class TracksChangeSnapshotDTO : ITracksChangeSnapshot<TrackInfoDTO>
{
    [JsonRequired]
    public DateTimeOffset CreatedAt { get; init; }
    [JsonRequired]
    public required IReadOnlyList<TrackInfoDTO> Added { get; init; }
    [JsonRequired]
    public required IReadOnlyList<TrackInfoDTO> Removed { get; init; }
}