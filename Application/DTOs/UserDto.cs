namespace NBP.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }

        public UserDto(string AccessToken, string RefreshToken, string UserName, string Role, int Id)
        {
            this.Id = Id;
            this.AccessToken = AccessToken;
            this.RefreshToken = RefreshToken;
            this.UserName = UserName;
            this.Role = Role;
        }
    }
}
