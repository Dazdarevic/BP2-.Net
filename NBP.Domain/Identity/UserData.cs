namespace NBP.Domain.Identity;

public class UserData
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}