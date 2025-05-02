using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SpotifyPlaylistQueryMod.Shared.Enums;
using SpotifyPlaylistQueryMod.Shared.Validation;

namespace SpotifyPlaylistQueryMod.Shared.API.DTO;

public record CreatePlaylistQueryDTO : IValidatableObject
{
    public string Name { get; set; } = nameof(Query);
    public string? TargetId { get; set; }
    [JsonRequired]
    public required string SourceId { get; set; }
    [JsonRequired]
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
                $"{nameof(SourceId)} and {nameof(TargetId)} must not be the same.",
                [nameof(SourceId), nameof(TargetId)]
            ));
        }
        if (!context.IsValidQueryString(Query))
        {
            results.Add(new ValidationResult(
                $"{nameof(Query)} must be valid and well-formed HTTP(S) url.",
                [nameof(Query)]
            ));
        }
        if (string.IsNullOrEmpty(Name))
        {
            results.Add(new ValidationResult(
                $"{nameof(Name)} must not be null or an empty string.",
                [nameof(Name)]
            ));
        }
        if (Name.Length >= 30)
        {
            results.Add(new ValidationResult(
                 $"{nameof(Name)} must be less than 30 characters long.",
                [nameof(Name)]
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
    [JsonRequired]
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
