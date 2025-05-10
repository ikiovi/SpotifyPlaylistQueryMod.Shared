using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class PlaylistChangeResponseDTO
{
    public int Position { get; init; }
    public required List<string> Add { get; set; }
    public required List<string> Remove { get; set; }
    public required PlaylistQueryInputType NewInputType { get; init; }
}