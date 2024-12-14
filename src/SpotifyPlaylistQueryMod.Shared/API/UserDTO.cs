using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.API;

public class UserDTO
{
    public required string Id { get; init; }
    public UserPrivileges Privileges { get; set; }
    public bool IsCollaborationEnabled { get; set; }
}

public sealed class UserCollaborationStatusUpdateDTO
{
    public bool IsCollaborationEnabled { get; set; }
}