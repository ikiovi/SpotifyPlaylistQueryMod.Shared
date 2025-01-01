using System.Text.Json.Serialization;
using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.API.DTO;

public class UserDTO
{
    [JsonRequired]
    public required string Id { get; init; }
    public UserPrivileges Privileges { get; set; }
    public bool IsCollaborationEnabled { get; set; }
}

public sealed class UserCollaborationStatusUpdateDTO
{
    public bool IsCollaborationEnabled { get; set; }
}