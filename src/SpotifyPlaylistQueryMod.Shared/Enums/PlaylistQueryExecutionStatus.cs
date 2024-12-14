namespace SpotifyPlaylistQueryMod.Shared.Enums;

[Flags]
public enum PlaylistQueryExecutionStatus
{
    Active = 0,
    Blocked = 1 << 1,
    NoReadAccess = 1 << 2,
    NoWriteAccess = 1 << 3
}