using SpotifyPlaylistQueryMod.Shared.Enums;

namespace SpotifyPlaylistQueryMod.Shared.API.DTO;

public record CreatePlaylistQueryDTO
{
    public string Name { get; set; } = nameof(Query);
    public string? TargetId { get; set; }
    public required string SourceId { get; set; }
    public required string Query { get; set; }
}

public record UpdatePlaylistQueryDTO : CreatePlaylistQueryDTO
{
    public bool IsPaused { get; set; }
}

public record PlaylistQueryDTO : UpdatePlaylistQueryDTO
{
    public required int Id { get; init; }
    public PlaylistQueryExecutionStatus ExecutionStatus { get; set; }
    public IEnumerable<string> ExecutionStatusStrings { get; }
    public bool IsSuperseded { get; set; }
    public bool IsNotificationOnly => TargetId == null && !IsSuperseded;
    public PlaylistQueryDTO(PlaylistQueryExecutionStatus status)
    {
        ExecutionStatus = status;

        if (status == PlaylistQueryExecutionStatus.Active)
        {
            ExecutionStatusStrings = [PlaylistQueryExecutionStatus.Active.ToString()];
            return;
        }

        ExecutionStatusStrings = Enum.GetValues<PlaylistQueryExecutionStatus>()
            .Skip(1)
            .Select(f => f.ToString())
            .ToList();
    }
}
