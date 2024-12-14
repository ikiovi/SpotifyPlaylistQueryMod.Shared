using System.ComponentModel.DataAnnotations;
using SpotifyPlaylistQueryMod.Shared.Enums;
using SpotifyPlaylistQueryMod.Shared.Validation;

namespace SpotifyPlaylistQueryMod.Shared.API;

public record CreatePlaylistQueryDTO : IValidatableObject
{
    public string? TargetId { get; set; }
    public required string SourceId { get; set; }
    public required string Query { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        List<ValidationResult?> results = [
            QueryValidationHelper.ValidateSpotifyId(SourceId, nameof(SourceId)),
            QueryValidationHelper.ValidateSpotifyId(TargetId, nameof(TargetId), true)
        ];

        if (TargetId == SourceId)
        {
            results.Add(new ValidationResult(
                $"{nameof(SourceId)} and {nameof(TargetId)} shouldn't be the same.",
                [nameof(SourceId), nameof(TargetId)]
            ));
        }
        if (!context.IsValidQueryString(Query))
        {
            results.Add(new ValidationResult(
                $"{nameof(Query)} should be valid http(s) url.",
                [nameof(Query)]
            ));
        }

        return results.OfType<ValidationResult>();
    }
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
