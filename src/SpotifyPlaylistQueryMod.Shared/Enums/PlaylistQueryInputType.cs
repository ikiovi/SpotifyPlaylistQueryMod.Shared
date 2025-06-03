namespace SpotifyPlaylistQueryMod.Shared.Enums;

[Flags]
public enum PlaylistQueryInputType
{
    CurrentSourcePlaylist = 1 << 0,
    CurrentTargetPlaylist = 1 << 1,
    ChangeHistory = 1 << 2
}
