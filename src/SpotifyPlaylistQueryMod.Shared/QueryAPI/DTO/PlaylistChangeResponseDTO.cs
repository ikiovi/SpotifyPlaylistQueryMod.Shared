using System.Text.Json.Serialization;
using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.QueryAPI.DTO;

public class PlaylistChangeResponseDTO
{
    public int Position { get; init; }
    [JsonRequired]
    public required List<string> Add { get; set; }
    [JsonRequired]
    public required List<string> Remove { get; set; }
    [JsonRequired]
    public required PlaylistQueryInputType NewInputType { get; init; }
}