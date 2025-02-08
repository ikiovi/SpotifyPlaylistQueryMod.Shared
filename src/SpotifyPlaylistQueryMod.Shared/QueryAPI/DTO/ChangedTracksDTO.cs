using System.Text.Json.Serialization;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class ChangedTracksDTO : IChangedTracks<BasicTrackInfoDTO>
{
    [JsonRequired]
    public required IReadOnlyList<BasicTrackInfoDTO> Added { get; init; }
    [JsonRequired]
    public required IReadOnlyList<BasicTrackInfoDTO> Removed { get; init; }
}