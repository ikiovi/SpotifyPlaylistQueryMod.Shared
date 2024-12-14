namespace SpotifyPlaylistQueryMod.Shared.Enums;

[Flags]
public enum PlaylistQueryInputType
{
    ModifiedSourcePlaylist = 1 << 0,
    OriginalSourcePlaylist = 1 << 1,
    CurrentTargetPlaylist = 1 << 2,
    ChangedTracks = 1 << 3
}
