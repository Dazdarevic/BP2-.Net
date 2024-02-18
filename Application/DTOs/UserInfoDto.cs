namespace NBP.Application.DTOs
{
    public class UserInfoDto
    {
        public int ID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BirthDate { get; set; }

        public string? UserName { get; set; }
        public string? Url { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? RegistrationDate { get; set; }
    }
}
