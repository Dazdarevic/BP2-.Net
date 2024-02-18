using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NBP.Domain.Identity;

public class User
{
    [Key]
    public int ID { get; set; }

    [Required(ErrorMessage = "Firstname is required.")]
    [StringLength(50, MinimumLength = 2)]
    [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numbers are not allowed.")]

    [Sieve(CanFilter = true, CanSort = true)]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Lastname is required.")]
    [StringLength(50, MinimumLength = 2)]
    [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numbers are not allowed.")]
    public string? LastName { get; set; }
    public string? BirthDate { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public string? UserName { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [Required]
    public string? Role { get; set; }
    public string? PhoneNumber { get; set; }

    [StringLength(200, MinimumLength = 8)]
    public string? Password { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string? Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }

    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }

}