using System.ComponentModel.DataAnnotations;

namespace HorseMoney.Domain.Dto.Account;

public record LoginDto
{
    [Required]
    public string Email { get; private set; }
    [Required]
    public string Password { get; private set; }
}